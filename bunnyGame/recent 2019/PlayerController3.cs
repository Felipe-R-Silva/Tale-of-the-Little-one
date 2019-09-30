using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    public float rotationRate = 360;
    public float rotatespeed=1;
    public float moveSpeed = 10;

     public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            print("I am here");
            transform.Rotate(0, 0, rotatespeed * rotationRate * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0,0, -rotatespeed * rotationRate * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(-transform.up * moveSpeed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(transform.up * moveSpeed, ForceMode.Force);
        }


    }


    private void Move(float input)
    {
        //transform.Translate(new Vector3(0,-1,0) * input * moveSpeed);
        rb.AddForce(-rb.transform.up * input * moveSpeed,ForceMode.Force);
    }
    private void Turn(float input)
    {

       transform.Rotate(0,input*rotationRate*Time.deltaTime,0);

    }
}
