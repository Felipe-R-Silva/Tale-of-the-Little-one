using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    [SerializeField]
    public float maxSpeed = 200f;
    [SerializeField]
    private float moveThrust;
    [SerializeField]
    private float horizontal_speed;
    [SerializeField]
    private float jumpThrust;
    [SerializeField]
    private float RunjumpForwardThrust;
    [SerializeField]
    public Rigidbody rb;
    //Make sure you attach a Rigidbody in the Inspector of this GameObject
    public Vector3 m_EulerAngleVelocity;
    [SerializeField]
    private bool canjump;
    [SerializeField]
    private bool canhop;
    [SerializeField]
    private float hopInterval;
    [SerializeField]
    private float BigJumpInterval;

    //Particles
    [SerializeField]
    private GameObject Smoke_Jump;
    [SerializeField]
    private GameObject Smoke_hopWalk;

    [SerializeField]
    public bool SlideON=false;


    void Start()
    {
        canjump = false;


        Cursor.visible = false;
        Screen.lockCursor = true;
        //Cursor.visible = false;
        //Set the axis the Rigidbody rotates in (100 in the y axis)
        //m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //limit max speed
        if (GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
        }
        //rotate right
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        //rotate left
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion deltaRotation = Quaternion.Euler(-1 * m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
    
    void OnCollisionStay(Collision collision)
    {
       
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "BreakableGround")
        {
            print("Onground");
            // BigUpJump
            // BigUpforwardJump
            BigUpJump();




            //IsolatedForwardMovement -horizontal
            if (Input.GetKey(KeyCode.W) && SlideON)
            {
                rb.AddForce(-transform.forward * horizontal_speed, ForceMode.Force);
            }
            //IsolatedBackMovement -horizontal
            if (Input.GetKey(KeyCode.S) && SlideON)
            {
                rb.AddForce(transform.forward * horizontal_speed, ForceMode.Force);
            }

            //ForwardMovement-Hop
            if (Input.GetKey(KeyCode.W) && canhop == false && !SlideON)
                {
                //set the hop variable delay in hopInterval
                canhop = true;
                StartCoroutine(SetMyJumpToFalse(callBack => {
                    // callBack is going to be null until it’s set
                    if (callBack != null)
                    {
                        // Now callBack acts as an int
                        canhop = callBack;
                        //print("callback : " + callBack);
                    }
                }, hopInterval));

                if (!SlideON)
                {
                    //hop veretical force
                    rb.AddForce(transform.up * moveThrust);
                }
                //no hoping only sliding-horiontal speed
                rb.AddForce(-transform.forward * horizontal_speed );
                }


            //walkBack-hopBack
                if (Input.GetKey(KeyCode.S) && canhop == false && !SlideON)
                {

                canhop = true; 
                StartCoroutine(SetMyJumpToFalse(callBack => {
                    // callBack is going to be null until it’s set
                    if (callBack != null)
                    {
                        // Now callBack acts as an int
                        canhop = callBack;
                        //print("callback : " + callBack);
                    }
                }, hopInterval));

                //jump
                if (!SlideON)
                {
                    //hop veretical force
                    rb.AddForce(transform.up * moveThrust);
                }
                //no hoping only sliding-horiontal speed
                rb.AddForce(transform.forward * moveThrust, ForceMode.Force);
                }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "BreakableGround")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                 Vector3 Location;
                Location = collision.contacts[0].point;
                Instantiate(Smoke_hopWalk, Location, this.transform.rotation);
            }
            Instantiate(Smoke_hopWalk, this.transform.position, this.transform.rotation);
        }
    }


    private IEnumerator SetMyJumpToFalse(System.Action<bool> callBack,float time)
    {
        yield return new WaitForSeconds(time);
        callBack(false);
    }

    private void BigUpJump()
    {
        //canjump = have I jumped before?
        if (Input.GetKey(KeyCode.Space) && canjump == false)
        {
            //fx smoke jump
            Instantiate(Smoke_Jump, this.transform.position, this.transform.rotation);

            //large jump is activated for hopInterval time
            canjump = true;
            StartCoroutine(SetMyJumpToFalse(callBack => {
                if (callBack != null)
                {
                    canjump = callBack;
                }
            }, BigJumpInterval));

            //jump  function
            rb.AddForce(transform.up * jumpThrust);

            if (Input.GetKey(KeyCode.W))
            {
                //move back
                rb.AddForce(-transform.forward * moveThrust / 2 * RunjumpForwardThrust);


            }


        }
    }


}
