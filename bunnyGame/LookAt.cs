using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    [SerializeField]
    public  GameObject target;


    // Update is called once per frame
    void FixedUpdate () {
        transform.LookAt(target.transform);

    }
}
