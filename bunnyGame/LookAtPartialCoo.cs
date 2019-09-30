using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPartialCoo : MonoBehaviour {

    [SerializeField]
    public  GameObject target;


    // Update is called once per frame
    void FixedUpdate () {
        //transform.LookAt(target.transform);
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));

    }
}
