using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMaster : MonoBehaviour {
    public float ClickDelayTime=0.3f;
    bool Clickable = true;
    [SerializeField]
    public GameObject Canvas;
    public Quest CarrotQuest;
    public GameObject Cart;
    public GameObject Player;
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            swapData();
            Canvas.SetActive(true);
        }

        if (CarrotQuest.currentState == 6 && PickUpControll.MyItem.name == "Scroll-Mail" && CarrotQuest.questState[CarrotQuest.currentState].NPCName == "president(6)")
        {
            CarrotQuest.questState[6].CompleatedRequirements = true;
        }

        if (CarrotQuest.currentState == 5 && PickUpControll.MyItem.name == "Scroll-Mail" && CarrotQuest.questState[CarrotQuest.currentState].NPCName== "FunnyEye-Bob(5)")
        {
            CarrotQuest.questState[5].CompleatedRequirements = true;
        }
        
    }
    //Canvas.SetActive(true);
        private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            

            if (Input.GetMouseButtonDown(1)&& Clickable)
            {
                
                //sets Click delay Time so the user wotn spam and bug the dialog
                StartCoroutine(ClickDelay());

                if (CarrotQuest.currentState < CarrotQuest.questState.Length-1 && CarrotQuest.questState[CarrotQuest.currentState].CompleatedRequirements)
                {
                    //invoke Event
                    CarrotQuest.questState[CarrotQuest.currentState].dialogEvent.Invoke();
                    //Go to next state
                    CarrotQuest.currentState++;
                    if (CarrotQuest.questState[CarrotQuest.currentState].NeedTeleport)
                    {
                        transform.position=CarrotQuest.questState[CarrotQuest.currentState].TeleportPoint.transform.position;
                        CarrotQuest.questState[CarrotQuest.currentState].NeedTeleport = false;
                    }
                    if (CarrotQuest.currentState==6 && false)
                    {
                        //quest Ended

                        Cart.GetComponent<CarrotsCart>().EmptyCart(ref Cart.GetComponent<CarrotsCart>().ActivationCount, Cart.GetComponent<CarrotsCart>().allChildren);

                    }
                }
                swapData();
            }


        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //CarrotQuest.questState[CarrotQuest.currentState]

            //Turn UI off
            Canvas.SetActive(false);
            CarrotQuest.NPC_Name_UI.text = null;
            CarrotQuest.NPC_Dialog.text = null;
            CarrotQuest.NPC_Image_UI.sprite = null;
        }
        


    }

    private void swapData()
    {
        //Turn on UI
        //Canvas.SetActive(true);

        //hidescrean Before turning on
        Canvas.GetComponent<Canvas>().enabled = false;
        //SetDialogBox


        if (CarrotQuest.questState[CarrotQuest.currentState].CompleatedRequirements) {
        //swap text and images
        CarrotQuest.NPC_Name_UI.text = CarrotQuest.questState[CarrotQuest.currentState].NPCName;
        CarrotQuest.NPC_Dialog.text = CarrotQuest.questState[CarrotQuest.currentState].NPC_Dialog;
        CarrotQuest.NPC_Image_UI.sprite = CarrotQuest.questState[CarrotQuest.currentState].NPC_Image;
        }
        else
        {
        CarrotQuest.NPC_Name_UI.text = CarrotQuest.questState[CarrotQuest.currentState].NPCName;
        CarrotQuest.NPC_Dialog.text = CarrotQuest.questState[CarrotQuest.currentState].NPC_NotCompleatedRequirements_Dialog;
        CarrotQuest.NPC_Image_UI.sprite = CarrotQuest.questState[CarrotQuest.currentState].NPC_Image;
        }

        //show to player
        Canvas.GetComponent<Canvas>().enabled = true;
    }
    
    IEnumerator ClickDelay()
    {
        Clickable = false;
        yield return new WaitForSeconds(ClickDelayTime);
        Clickable = true;
    }
}

