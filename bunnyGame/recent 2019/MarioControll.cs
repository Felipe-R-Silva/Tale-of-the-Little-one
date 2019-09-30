using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioControll : MonoBehaviour {

    /// <summary>
    /// 1. 8-directional movement
    /// 2. stop and face current direction when input is absent
    /// </summary>
    public GameObject playerOBJ;

    public float velocity = 5;
    public float turnSpeed = 10;


    Vector2 input;
    float angle;
    public Rigidbody rb;

    Quaternion targetRotation;
    public Transform cam;

    public GameObject PlayerIwantToControll;
    void Start()
    {
        rb = PlayerIwantToControll.GetComponent<Rigidbody>();
        //cam = Camera.main.transform;

    }
    void Update()
    {

        GetInput();
        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1)
        {
            return;
        }
        CalculateDirectios();
        Rotate();
        Move();

    }
    ///<sumary>
    ///input vased on Horizontal (a,d,<,>)
    ///</sumary>
    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
    ///<sumary>
    ///Directions relative to camera's rotation
    ///</sumary>
    void CalculateDirectios()
    {

        angle = Mathf.Atan2(input.x, input.y);//look up atan2
        angle = Mathf.Rad2Deg * angle;
        //print(angle);
        angle += cam.eulerAngles.y;
    }
    ///<sumary>
    ///Rotate towards the calculated angle
    ///</sumary>
    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        PlayerIwantToControll.transform.rotation = Quaternion.Slerp(PlayerIwantToControll.transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

    }
    ///<sumary>
    ///This player only moves along its own forward axis
    ///</sumary>
    void Move()
    {
        //transform.position += transform.forward * velocity * Time.deltaTime;
        rb.AddForce(rb.transform.forward * velocity, ForceMode.Force);
    }
}
