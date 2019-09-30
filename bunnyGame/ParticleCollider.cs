using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollider : MonoBehaviour {

    [SerializeField]
    private List<GameObject> particles= new List<GameObject>();

    public string TagName;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == TagName)
        {

                Instantiate(particles[0], collision.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                Instantiate(particles[1], collision.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));

            //Instantiate(Smoke_hopWalk, contact.transform.position, this.transform.rotation);

            //Instantiate(particles[0], new Vector3(this.transform.position.x, this.transform.position.y, -this.transform.position.z), this.transform.rotation);
        }
    }
}
