using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgonreCollision : MonoBehaviour {

    
    [Header("Ignore the collisions between layer : x")]
    [Header("and layer : y")]
    public Vector2[] IgnoreCollision;
	void Start () {
        foreach (Vector2 tuple in IgnoreCollision)
        {
            Physics.IgnoreLayerCollision((int)tuple.x, (int)tuple.y);
        }

    }
}

