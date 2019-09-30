using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KEYS
{
    [System.Serializable]
    public class ControllsController : MonoBehaviour
    {
        //Buttons
        public string Jump;
        public string PickUp;
        public string Atack;
        public string Action;
        public string Menu;

        //Axis move
        public string RotateX;
        public string Acelerate;
        public string Forward;
        public string Backwards;

        //Axis Camera
        public string Camera;



        static public ControllsController Instance { get { return _instance; } }
        static protected ControllsController _instance;
        //Handeling exeptions do not edit this.
        public void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning("ControllsKeyboardMouse is already in play. Deleting new!", gameObject);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Instantiating new", gameObject);
                _instance = this;
            }
        }

        //acess
        //Input.GetKeyDown(FilteredKey) //buttons
        //Input.GetMouseButtonDown(keyPress)//mouse

        public void Start()
        {
            /*
            Action = "return";
            Menu = "escape";
            
            */
            PickUp = "Y-Controller";
            Atack = "X-Controller";
            Forward = "TriggersIndependent";
            Acelerate = "TriggersIndependent";
            RotateX = "LeftStick";
            Camera = "RightStick";
            Jump = "A-Controller";
            Backwards = "DPAD";
        }

    }
}
