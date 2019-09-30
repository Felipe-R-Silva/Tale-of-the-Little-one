using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopTrigger : MonoBehaviour
{
    [Header("It Will Run all of the calls below")]
    public UnityEvent ActionEventCall; // Events to fire when we enter the trigger
    //Activate this script when enterring the shop
    void Update()
    {
        if (Input.GetKey(KEYS.ControllsKeyboardMouse.Instance.Action))
        {
            ActionEventCall.Invoke();
        }

    }

    //Shop functions

}
