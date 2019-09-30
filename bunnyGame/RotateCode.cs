using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCode : MonoBehaviour {

  

    public float rotationleft ;
    public float TotalRotation = 360;
    public float numberOfRotation = 0;
    public float time=1;

    public bool backflip;
    public bool frontflip;

    //Atack
    [SerializeField]
    private GameObject atackColider;

    public bool atacking;

    [SerializeField]
    private float atackDamage=100;

    private void Start()
    {
        if(backflip && frontflip)
        {
            frontflip = false;
        }
        atackColider.SetActive(false);
        rotationleft = 0;
        atacking = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && atacking == false)
        {
            //turn on atack colider
            atackColider.SetActive(true);
            //atack on
            atacking = true;
            rotationleft = numberOfRotation* TotalRotation;
            atacking = true;

            StartCoroutine(atack(callBack => {
                // callBack is going to be null until it’s set
                if (callBack != null)
                {
                    // Now callBack acts as an int
                    if(callBack == 0)
                    {
                        atacking = false ;
                        rotationleft = 0;
                        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
                        //turn off atack colider
                        atackColider.SetActive(false);

                       // print("rotated correctly");
                    }
                    if (callBack != 0)
                    {
                        rotationleft=callBack;
                       // print("callback : " + callBack);
                       // print("Error Rotating");
                        //atackCube.SetActive(false);
                    }
                }
            }, rotationleft));
        }

         
    }
    private IEnumerator atack(System.Action<float> callBack, float Irotationleft)
    {
        Debug.Log("Hello Before Waiting");
        while (Irotationleft !=0)
        {

            float rotation = TotalRotation * Time.deltaTime / time;

            if (Irotationleft > rotation)
            {
                Irotationleft -= rotation;
                callBack(Irotationleft);
                //print(Irotationleft);
            }
            else
            {
                rotation = Irotationleft;
                Irotationleft = 0;
                atacking = false;
            }
            if (backflip)
            {
                transform.Rotate(rotation, 0, 0);
            }
            else if(frontflip)
            {
                transform.Rotate(-rotation, 0, 0);
            }

            yield return null; //Don't freeze Unity
        }
        callBack(Irotationleft);

    }

    public void rotate(GameObject atackColider)
    {
    //header
     float rotationleft;
     float TotalRotation = 360;
     float numberOfRotation = 0;
     float time = 1;

     bool flip;

     bool atacking;

     float atackDamage = 100;


        //initiate
        atackColider.SetActive(false);
        rotationleft = 0;
        atacking = false;

        //updare
    }
}
