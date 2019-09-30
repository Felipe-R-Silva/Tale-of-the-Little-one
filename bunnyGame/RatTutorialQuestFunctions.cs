using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatTutorialQuestFunctions : MonoBehaviour {
    [Header("PlayerGameObject")]
    public GameObject Player;
    [Header("CameraChangeTarget")]
    public GameObject Mail;
    public GameObject PivotCamera;
    [Header("ActivateScript")]
    public GameObject MailOBJScript;
    [Header("ActivateScrollTutorial")]
    public GameObject OBJPickUpScrollTutorial;
    public GameObject OBJJumpAtackTutorial;
    [Header("testCallDialog")]
    public GameObject Canvas;

    public void CameraChangeToMail()
    {
        PivotCamera.GetComponent<FolowObject>().target = Mail;
    }
    public void CameraChangeToPlayer()
    {
        PivotCamera.GetComponent<FolowObject>().target = Player;
        OBJJumpAtackTutorial.SetActive(true);
    }
    public void DropMailOntree()
    {
        MailOBJScript.GetComponent<FolowObject>().enabled = true;
    }
    public void DropScrollFromtree()
    {
        MailOBJScript.GetComponent<FolowObject>().enabled = false;
        MailOBJScript.GetComponent<Rigidbody>().useGravity = true;
        OBJPickUpScrollTutorial.SetActive(true);
    }


    public void TurnCanvasOn()
    {
        Canvas.SetActive(true);
    }
    public void TurnCanvasOff()
    {
        Canvas.SetActive(false);
    }
    public void NextState()
    {//marktrue
        this.GetComponent<QuestMaster>().CarrotQuest.questState[this.GetComponent<QuestMaster>().CarrotQuest.currentState].CompleatedRequirements = true;
        this.GetComponent<QuestMaster>().CarrotQuest.currentState++; ;
    }
    public void CurrentStateTrue()
    {
        this.GetComponent<QuestMaster>().CarrotQuest.questState[this.GetComponent<QuestMaster>().CarrotQuest.currentState].CompleatedRequirements = true;
    }

    public void TeleportQuestBunnyMayor()
    {
        transform.position = this.GetComponent<QuestMaster>().CarrotQuest.questState[this.GetComponent<QuestMaster>().CarrotQuest.currentState].TeleportPoint.transform.position;
        this.GetComponent<QuestMaster>().CarrotQuest.questState[this.GetComponent<QuestMaster>().CarrotQuest.currentState].NeedTeleport = false;
    }
    public void EndTutorialChapter()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialEnd-Ch1"); 
    }


}
