using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class NPCState  {
    [SerializeField]
   // [TextArea]
    public string NPCName;
    [SerializeField]
    public Sprite NPC_Image;
    [SerializeField]
    [TextArea]
    public string NPC_Dialog;

    [SerializeField]
    public bool CompleatedRequirements;
    [SerializeField]
    public UnityEvent dialogEvent; // Events to fire when we enter the trigger

    [SerializeField]
    [TextArea]
    public string NPC_NotCompleatedRequirements_Dialog;
    [SerializeField]
    public bool NeedTeleport=false;
    [SerializeField]
    public GameObject TeleportPoint;
}
