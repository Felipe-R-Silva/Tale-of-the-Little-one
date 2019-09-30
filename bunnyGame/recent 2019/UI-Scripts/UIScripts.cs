using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScripts : MonoBehaviour
{
    public void OpenCloseMenu(GameObject target)
    {
        if (target.activeSelf)
        {
            Time.timeScale = 1;//unpause
            Cursor.visible = false;//hide mose
            Cursor.lockState = CursorLockMode.Locked;//lock mouse
            GUN.PlayerMaster.Instance.PlayerCamera.GetComponent<OrbitalCameraCOntroll>().enabled = true;//unlock camera
        }
        else
        {
            Time.timeScale = 0;//pause
            Cursor.visible = true;//show mouse
            Cursor.lockState = CursorLockMode.None;//unlock mouse
            GUN.PlayerMaster.Instance.PlayerCamera.GetComponent<OrbitalCameraCOntroll>().enabled = false;//lock camera
        }
        target.SetActive(!target.activeSelf);
    }
}
