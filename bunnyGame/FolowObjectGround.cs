using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowObjectGround : MonoBehaviour {

    public GameObject target;
    public float speed;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z), speed);
        //transform.position = Vector3.Lerp(this.transform.position, target.transform.position, speed*Time.time);

    }
}
