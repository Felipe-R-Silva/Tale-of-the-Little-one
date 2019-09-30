using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrane : MonoBehaviour
{
    public Animator animator;
    public GameObject CraneClaw;
    public GameObject Trail;
    public float moveTrailUpDelay;
    public bool COrotineRunning;
    public bool holdingtrack;
    public bool TimeToGrabTrack ;
    public bool TimeToPlaceBackTrack;
    public float CraneSpeed;
    public Transform initialPosition;
    public Transform finalPosition;

    public float UpdateSpeed;



    void Start()
    {
        COrotineRunning = false;
        holdingtrack = false;
        TimeToGrabTrack =false;
        TimeToPlaceBackTrack=false;
        StartCoroutine(ClawUpdate(UpdateSpeed));
    }

    IEnumerator ClawUpdate(float speed)
    {
        if (speed == 0)
        {
            speed = 0.01f;
        }
        while (true)
        {
            yield return new WaitForSeconds(speed);
            //code here
            if (!holdingtrack && TimeToGrabTrack && !COrotineRunning)
            {
                COrotineRunning = true;
                StartCoroutine(MoveCraneClaw(finalPosition.position, CraneSpeed, callback => 
                {
                    holdingtrack = true;
                    TimeToGrabTrack = false;

                    StartCoroutine(MoveCraneClawUp(initialPosition.position, CraneSpeed, callback2 =>
                    {
                        holdingtrack = true;
                        TimeToGrabTrack = false;
                        COrotineRunning = false;
                    }));
                }));
            }
            else if (holdingtrack && TimeToPlaceBackTrack && !COrotineRunning)
            {
                COrotineRunning = true;
                StartCoroutine(MoveCraneClaw(finalPosition.position, CraneSpeed, callback =>
                {
                    holdingtrack = true;
                    TimeToGrabTrack = false;
                }));
            }

        }
    }

    IEnumerator MoveCraneClaw(Vector3 FinalPosition, float speed,System.Action<bool>callback)
    {
        //Open Claw

        animator.SetBool("ClawIsOpen", true);
        animator.SetBool("Idle", false);
        // Keep a note of the time the movement started.
        Vector3 InitialPosition = CraneClaw.transform.position;
        var startTime = Time.time;
        // Calculate the journey length.
        var journeyLength = Vector3.Distance(InitialPosition, FinalPosition);
        //-------------
        float fracJourney;
        do
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            CraneClaw.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, fracJourney);
            yield return null;
        } while (fracJourney<0.9);
        CraneClaw.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, 1);
        // CloseClaw
        animator.SetBool("ClawIsOpen", false);

        //Parent Trail To Crane
        Trail.transform.parent = CraneClaw.transform;
        callback(false);
    }
    IEnumerator MoveCraneClawUp(Vector3 FinalPosition, float speed, System.Action<bool> callback)
    {
        yield return new WaitForSeconds(moveTrailUpDelay);
        // Keep a note of the time the movement started.
        Vector3 InitialPosition = CraneClaw.transform.position;
        var startTime = Time.time;
        // Calculate the journey length.
        var journeyLength = Vector3.Distance(InitialPosition, FinalPosition);
        //-------------
        float fracJourney;
        do
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            CraneClaw.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, fracJourney);
            yield return null;
        } while (fracJourney < 0.9);
        CraneClaw.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, 1);
        callback(false);

    }
    public void TimeToPlaceBackFunc()
    {
        TimeToPlaceBackTrack = true;
    }
}




