using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    public GameObject RatCraneTimelineObj;
    public GameObject CameraMain;
    public GameObject InstantiatePoint;
    public GameObject ButtonObj;
    public GameObject ButtonInHandOfRat;

    public void Instantiateaprefab()
    {
        ButtonObj.SetActive(true);
        ButtonObj.transform.position = InstantiatePoint.transform.position;
    }
    public void EndTimeline()
    {
        RatCraneTimelineObj.SetActive(false);
        CameraMain.GetComponent<Cinemachine.CinemachineBrain>().enabled = false;
    }
    public void HideButtonObj()
    {
        ButtonInHandOfRat.SetActive(false);
    }
}
