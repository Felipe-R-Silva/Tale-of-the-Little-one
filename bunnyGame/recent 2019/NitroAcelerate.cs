using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroAcelerate : MonoBehaviour
{
    public GameObject FillNitroMeter;
    Vector3 DesiredFillAmount;
    public MoveControll playerscript;
    public Text NitroText;
    public bool usingNITRO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        usingNITRO=checkIfUsingNitro(playerscript);

    }
    public bool checkIfUsingNitro(MoveControll playerscript)
    {
        if (!playerscript.HasNitro)
        {
            FillNitroMeter.SetActive(false);
            return false;
        }
        else
        {
            if (!FillNitroMeter.activeSelf)
            {
                FillNitroMeter.SetActive(true);
            }
        }
        return true;
    }
}
