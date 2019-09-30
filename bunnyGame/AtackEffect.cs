using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackEffect : MonoBehaviour {

    // Use this for initialization

    private GameObject player;
    [SerializeField]
    Vector3 direction;

    public float Atackforce;

    void Start () {
        player = transform.root.gameObject;
       
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(player.transform.position, transform.position, Color.red);
        direction = transform.position - player.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        other.GetComponent<Rigidbody>().AddForce(direction*Atackforce, ForceMode.Impulse);

        if ( other.gameObject.tag == "BreakableGround")
        {

            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<Rigidbody>().AddForce(direction * Atackforce, ForceMode.Impulse);
        }

    }
}
