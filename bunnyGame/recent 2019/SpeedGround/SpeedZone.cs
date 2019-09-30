using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedZone : MonoBehaviour
{
    bool enteredZone;
    public GameObject ExitPoint;
    public float PowerSpeed;

    GameObject Player;
    private void Start()
    {
        enteredZone = false;
    }
    void OnTriggerEnter(Collider theCollision) // C#, type first, name in second
    {
        if (theCollision.gameObject.tag == "Player" && !enteredZone)
        {
            Player = theCollision.transform.root.gameObject;
            enteredZone = true;
            //disable player 
            turnMoveAndRotate_ON_Off(false, theCollision.gameObject);
            print("I Entered Slipery Ground");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player"&& enteredZone)
        {
            enteredZone = false;
            //eneble player
            turnMoveAndRotate_ON_Off(true, other.gameObject);
        }
    }
    private void Update()
    {
        if (enteredZone)
        {
            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, transform.rotation * Quaternion.AngleAxis(-90, Vector3.up), 1 * Time.deltaTime);
            var heading = ExitPoint.transform.position - Player.transform.position;
            Player.GetComponent<Rigidbody>().AddForce(heading * PowerSpeed * Time.deltaTime, ForceMode.Force);
        }
        
    }
    public void turnMoveAndRotate_ON_Off(bool changeToThis,GameObject playerf)
    {
        //playerf.transform.root.gameObject.GetComponent<MoveControll>().enabled = false;
        playerf.transform.root.gameObject.GetComponent<MoveControll>().CanMove = changeToThis;
        playerf.transform.root.gameObject.GetComponent<MoveControll>().CanRotate = changeToThis;
    }
}
