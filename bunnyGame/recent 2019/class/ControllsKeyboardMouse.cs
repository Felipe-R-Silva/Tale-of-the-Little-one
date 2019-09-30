using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KEYS
{
    [System.Serializable]
    public class ControllsKeyboardMouse : MonoBehaviour
    {
        //Buttons
        [KeySelector]
        public string Jump;
        [KeySelector]
        public string PickUp;
        [KeySelector]
        public string Atack;
        [KeySelector]
        public string Action;
        [KeySelector]
        public string Menu;

        //Axis move
        [KeySelector]
        public string Right;
        [KeySelector]
        public string Left;
        [KeySelector]
        public string Forward;
        [KeySelector]
        public string Acelerate;
        [KeySelector]
        public string Backwards;
        //Axis Camera
        public string Camera;



        static public ControllsKeyboardMouse Instance { get { return _instance; } }
        static protected ControllsKeyboardMouse _instance;
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
            Jump = "space";
            PickUp = "Right_mouse";
            Atack = "Left_mouse";
            Action = "return";
            Menu = "escape";

            Acelerate = "left shift";
            Right = "d";
            Left = "a";
            Forward = "w";
            Backwards = "s";

            Camera = "Mouse";
        }

    }
}
