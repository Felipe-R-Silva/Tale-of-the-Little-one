using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform PlayerTransform;

    private Vector3 _cameraOffset;
    [Range(0.01f,1.0f)]
    public float SmoothFactor = 0.5f;

    public float desiredDistance;

	// Use this for initialization
	void Start () {
        _cameraOffset = transform.position - PlayerTransform.position;
    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(PlayerTransform.position, transform.position);

        Vector3 newPos = PlayerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

    }
}
