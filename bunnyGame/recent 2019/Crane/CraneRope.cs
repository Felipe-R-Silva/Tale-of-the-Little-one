using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneRope : MonoBehaviour
{
    public GameObject TopRopePivot;
    public GameObject ClawRopePivot;
    LineRenderer rope;
    // Start is called before the first frame update
    void Start()
    {
        rope = this.gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rope.SetPosition(0, TopRopePivot.transform.position);
        rope.SetPosition(1, ClawRopePivot.transform.position);
    }
}
