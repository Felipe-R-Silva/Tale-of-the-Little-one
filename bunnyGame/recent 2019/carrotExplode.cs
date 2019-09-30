using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class carrotExplode : MonoBehaviour
{
    public GameObject explosionFX;
    public UnityEvent OnTrigger;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            GameObject g = Instantiate(explosionFX, transform.position, Quaternion.identity);
            OnTrigger.Invoke();
            GetComponent<BoxCollider>().isTrigger = true;
            Destroy(this.gameObject);
        }
    }
}
