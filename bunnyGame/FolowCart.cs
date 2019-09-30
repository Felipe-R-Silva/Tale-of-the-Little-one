using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowCart : MonoBehaviour {
    public GameObject targetIsrotatingwith;
    public GameObject target;
    public float speed;
    public float rotatespeed;
    public bool cartIsfolowing=false;
    // Use this for initialization

    private void Start()
    {
        this.transform.eulerAngles = targetIsrotatingwith.transform.eulerAngles;
    }
    // Update is called once per frame
    void Update () {
        if (cartIsfolowing)
        {
            this.transform.rotation = targetIsrotatingwith.transform.rotation;
            transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed);
        }


        


    }
}
