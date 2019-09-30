using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerVideogame : MonoBehaviour
{
    string FilteredKey;
    // Start is called before the first frame update
    void Start()
    {
        FilteredKey = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            transform.Translate(0, 10*Time.deltaTime, 0);
        }
    }
}
