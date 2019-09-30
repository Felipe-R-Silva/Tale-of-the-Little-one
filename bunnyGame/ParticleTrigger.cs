using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour {

    [SerializeField]
    private List<GameObject> particles= new List<GameObject>();
    public string TagName;

    public bool SpawnOnThis;
    public bool SpawnOnTarget;
    public bool useTransformForRotation;

    public Vector3 EulerAjustAngle;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagName)
        {
            if (SpawnOnTarget)
            {
                if (useTransformForRotation)
                {
                    Instantiate(particles[0], other.transform.position,Quaternion.Euler( this.transform.eulerAngles + EulerAjustAngle));
                    Instantiate(particles[1], other.transform.position, Quaternion.Euler(this.transform.eulerAngles + EulerAjustAngle));
                }
                else
                {
                    Instantiate(particles[0], transform.position, Quaternion.Euler(EulerAjustAngle));
                    Instantiate(particles[1], transform.position, Quaternion.Euler(EulerAjustAngle));
                }
                
            }
            if (SpawnOnThis)
            {
                if (useTransformForRotation)
                {
                    Instantiate(particles[0], transform.position, Quaternion.Euler(this.transform.eulerAngles + EulerAjustAngle));
                    Instantiate(particles[1], transform.position, Quaternion.Euler(this.transform.eulerAngles + EulerAjustAngle));
                }
                else
                {
                    Instantiate(particles[0], transform.position, Quaternion.Euler(EulerAjustAngle));
                    Instantiate(particles[1], transform.position, Quaternion.Euler(EulerAjustAngle));
                }
            }

                //Instantiate(Smoke_hopWalk, contact.transform.position, this.transform.rotation);

                //Instantiate(particles[0], new Vector3(this.transform.position.x, this.transform.position.y, -this.transform.position.z), this.transform.rotation);
            }
    }
}
