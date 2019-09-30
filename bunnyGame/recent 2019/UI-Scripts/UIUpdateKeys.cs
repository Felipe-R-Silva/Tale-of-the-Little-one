using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdateKeys : MonoBehaviour
{
    public Text Jump;
    public Text  PickUp;
    public Text Atack;
    public Text Action;
    public Text Menu;
    //Axis move
    public Text Right;
    public Text Left;
    public Text Acelerate;
    public Text Forward;
    public Text Backwards;

    //Axis Camera
    public Text Camera;

    //public Text CameraMouseY;

    // Start is called before the first frame update
    void OnEnable()
    {
        UpdateTextsOfKeyboardMouseMenu();
    }
    public void UpdateTextsOfKeyboardMouseMenu()
    {
        Jump.text = KEYS.ControllsKeyboardMouse.Instance.Jump;
        PickUp.text = KEYS.ControllsKeyboardMouse.Instance.PickUp;
        Atack.text = KEYS.ControllsKeyboardMouse.Instance.Atack;
        Action.text = KEYS.ControllsKeyboardMouse.Instance.Action;
        Menu.text = KEYS.ControllsKeyboardMouse.Instance.Menu;

        Right.text = KEYS.ControllsKeyboardMouse.Instance.Right;
        Left.text = KEYS.ControllsKeyboardMouse.Instance.Left;
        Acelerate.text = KEYS.ControllsKeyboardMouse.Instance.Acelerate;
        Forward.text = KEYS.ControllsKeyboardMouse.Instance.Forward;
        Backwards.text = KEYS.ControllsKeyboardMouse.Instance.Backwards;

        Camera.text = "Mouse-setByHand";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
