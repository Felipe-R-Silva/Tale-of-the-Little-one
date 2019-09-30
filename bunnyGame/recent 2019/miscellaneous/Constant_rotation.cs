using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant_rotation : MonoBehaviour
{
    public Vector3 rotateDirection;
    public bool randomRotation;
    public float speed;
    public float refreshTime;

    // Update is called once per frame
    void Start()
    {
        if (!randomRotation)
        {
            StartCoroutine(rotate(this.gameObject, rotateDirection, speed, refreshTime));
        }
        else
        {
            float randomnumberX = Random.Range(-10.0f, 10.0f);
            float randomnumberY = Random.Range(-10.0f, 10.0f);
            float randomnumberZ = Random.Range(-10.0f, 10.0f);
            Vector3 RandomrotateDirection = new Vector3(randomnumberX, randomnumberY, randomnumberZ);
            StartCoroutine(rotate(this.gameObject, rotateDirection, speed, refreshTime));
        }
    }

    IEnumerator rotate(GameObject me,Vector3 dir,float speed,float Time)
    {
        while (true)
        {
            yield return new WaitForSeconds(Time);
            transform.Rotate(dir.normalized * speed);
        }

    }
}
