using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogText : MonoBehaviour
{
    public Text refTextObj;
    public int currentDialogID=0;
    [TextArea(10, 10)]
    public string[] Dialogs;
    // Update is called once per frame
    public void changeDialog()
    {
        if (currentDialogID == 4)
        {
            refTextObj.color = Color.green;
        }
        refTextObj.text = Dialogs[currentDialogID];
        currentDialogID++;
    }

    public void TurnGameObjectOn()
    {
        this.gameObject.SetActive(true);
    }
    public void TurnGameObjectOff()
    {
        this.gameObject.SetActive(false);
    }
}
