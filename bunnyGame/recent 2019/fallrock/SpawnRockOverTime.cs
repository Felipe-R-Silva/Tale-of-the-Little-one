using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRockOverTime : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] rocks;
    public Transform SpawnPoint;
    public float timeDelay;
    public bool RandomStartDelay;
    public float startDelay;
    public GameObject FX;
    void Start()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            if (hit.point!=null)
            {
                FX.transform.position = hit.point + new Vector3(0, 0.2f, 0);
            }
        }
            if (RandomStartDelay)
        {
            
            StartCoroutine(StartDelay(timeDelay, Random.Range(0f, 6f)));
        }
        else
        StartCoroutine(StartDelay(timeDelay, startDelay));
    }
    IEnumerator waitTime(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time * 2/4);
            FX.SetActive(true);
            yield return new WaitForSeconds(time * 1/4);
            SpawnRock(rocks, SpawnPoint);
            
        }
    }
    IEnumerator StartDelay(float time, float startDelay)
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(waitTime(time));
    }
    public void SpawnRock(GameObject[] Prefabs, Transform Place)
    {
        GameObject i= Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], Place.position, Place.rotation);
        //parent to this prefab
        i.transform.parent = this.transform;

        Destroy(i, 5);
    }
}
