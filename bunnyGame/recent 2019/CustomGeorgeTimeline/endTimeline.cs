using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTimeline : MonoBehaviour
{
    public GameObject TimelineObj;
    public GameObject CameraMain;
    // Start is called before the first frame update
    public void EndTimeline()
    {
        TimelineObj.SetActive(false);
        CameraMain.GetComponent<Cinemachine.CinemachineBrain>().enabled = false;
    }
}
