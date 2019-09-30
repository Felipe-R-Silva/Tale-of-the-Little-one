using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineTrack : MonoBehaviour
{
    public GameObject player;
    public Transform[] target;
    public float speed;
    float currentSpeed;
    private int current;

    private void Start()
    {
        currentSpeed = speed;
    }
    public bool loopMovement;
    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentSpeed = speed;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            currentSpeed = 0;
        }
        */
        float dist = Vector3.Distance(player.transform.position, new Vector3(target[current].transform.position.x, player.transform.position.y, target[current].transform.position.z));
        if (dist>1)
        {   
            Vector3 PositionToLook = new Vector3(target[current].transform.position.x, player.transform.position.y, target[current].transform.position.z);
            Vector3 ReversedToLook = 2 * player.transform.position - PositionToLook;
            //Interupt Sequence If jumps
            if (Input.GetKey(KEYS.ControllsKeyboardMouse.Instance.Jump))
            {
                EndOfTrack();
            }
            //look at
            player.transform.LookAt(ReversedToLook);
            //move
            Vector3 pos = Vector3.MoveTowards(player.transform.position, PositionToLook,currentSpeed*Time.deltaTime);
            player.GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            if (loopMovement)
            {
                current = (current + 1) % target.Length;
            }
            else
            {
                if(current +1< target.Length)
                {
                    current = (current + 1);
                }
                else
                {
                    EndOfTrack();

                }
            }
        }
    }
    public void setcurrentSpeed()
    {
        currentSpeed = player.GetComponent<Rigidbody>().velocity.magnitude/2;
    }
    public void setPlayerMovement(bool define)
    {
        player.GetComponent<MoveControll>().CanMove = define;
        player.GetComponent<MoveControll>().CanRotate = define;
    }
    public void EndOfTrack()
    {
        this.gameObject.SetActive(false);
        current = 0;
        player.GetComponent<Rigidbody>().AddForce(player.GetComponent<MoveControll>().FixedForwardSlope * currentSpeed, ForceMode.Impulse);
        setPlayerMovement(true);
    }
}
