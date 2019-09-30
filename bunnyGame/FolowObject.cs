using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowObject : MonoBehaviour {

    public GameObject target;
    public float speed;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
       transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed);
        //transform.position = Vector3.Lerp(this.transform.position, target.transform.position, speed*Time.time);

    }
}
