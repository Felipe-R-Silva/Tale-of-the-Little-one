using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructFX : MonoBehaviour
{
    [TagSelector]
    public string[] TagFilterArray = new string[] { };
    public GameObject FX;
    public float selfdistructtime;
    GameObject parent;
    private void Start()
    {
        parent = transform.parent.gameObject;
        while (parent.GetComponent<SpawnRockOverTime>() == null && transform.parent.parent != null)
        {
            parent = parent.transform.parent.gameObject;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        foreach (var item in TagFilterArray)
        {
            if (collision.transform.tag == item)
            {
                //instantiate FX
                Instantiate(FX, transform.position, Quaternion.Euler(90, 0, 0));
                //self destrucutin
                
                parent.GetComponent<SpawnRockOverTime>().FX.SetActive(false);
                Destroy(this.gameObject, selfdistructtime);
            }

        }

    }
}
