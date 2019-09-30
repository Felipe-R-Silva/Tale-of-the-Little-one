using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Quest {
    [SerializeField]
    public Text NPC_Name_UI;
    [SerializeField]
    public Text NPC_Dialog;
    [SerializeField]
    public Image NPC_Image_UI;

    [SerializeField]
    public NPCState[] questState;
    [SerializeField]
    public int QuestID;
    [SerializeField]
    public int currentState;
}
