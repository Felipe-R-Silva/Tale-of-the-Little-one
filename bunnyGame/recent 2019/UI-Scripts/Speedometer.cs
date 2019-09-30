using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public GameObject flame, pointer ,PlayerCar;
    Vector3 PointerDesiredRotation;
    public MoveControll playerscript;
    public Text SpeedText;
    float flameDesiredFillAmount;
    float CarMagnitudeSpeed;
    //pointeir goes from 230(0) to 0(max)
    void Start()
    {
        PointerDesiredRotation = Vector3.zero;
        flameDesiredFillAmount = 0;
        flame.GetComponent<Image>().fillAmount = flameDesiredFillAmount;//set current fill 

        //Initialize speedometer
        RectTransform rectTransform = pointer.GetComponent<RectTransform>();
        rectTransform.Rotate(new Vector3(0, 0, 230));

    }
    private void Update()
    {
        CarMagnitudeSpeed=UpdateCarMagnitudeSpeed(PlayerCar);//get speed magnitude
        SpeedText.text = CarMagnitudeSpeed.ToString();//sets teh speedometer number 
        float flameDesiredFillAmount = UpdateSPeedometerPointerRotation(pointer, UpdateCarMagnitudeSpeed(PlayerCar), playerscript.maxSpeedNitro, 0, 230);
        PaintFlame(flameDesiredFillAmount, flame.GetComponent<Image>());
    }
    public float UpdateSPeedometerPointerRotation(GameObject pointer,float CarMagnitude, float CarMaxSpeed, float MaxTreshhold ,float MinTreshHold)
    {
        RectTransform rectTransform = pointer.GetComponent<RectTransform>();
        float percentageMagnitude = CarMagnitude / CarMaxSpeed;
        float DesiredRotation = (1 / (MaxTreshhold - MinTreshHold)) * percentageMagnitude;

        //print(percentageMagnitude);
        //rectTransform.eulerAngles=new Vector3(0, 0, 30);

        // rectTransform.Rotate(new Vector3(0, 0, percentageMagnitude * (MaxTreshhold - MinTreshHold)*-1));
        //this is the value I want to rotate Z--> 230-((percentageMagnitude) * (MaxTreshhold - MinTreshHold) * -1)
        float AngletoRotate = 230 - ((percentageMagnitude) * (MaxTreshhold - MinTreshHold) * -1);
        //rectTransform.rotation = Quaternion.Euler(0, 0, 230-((percentageMagnitude) * (MaxTreshhold - MinTreshHold) * -1));
        //rectTransform.rotation = Quaternion.AngleAxis(AngletoRotate, pointer.transform.forward);
        rectTransform.rotation = Quaternion.Euler(rectTransform.eulerAngles.x, rectTransform.eulerAngles.y, AngletoRotate);
        return 1-(AngletoRotate/230);//0-1
    }
    public float UpdateCarMagnitudeSpeed(GameObject car)
    {
        
        if (car.GetComponent<Rigidbody>().velocity.magnitude < 0.01f)
        {
            return 0;
        }
        else
        return car.GetComponent<Rigidbody>().velocity.magnitude;

    }
    public void PaintFlame(float percentagefill,Image fillImage)
    {
        double NewValue = (((percentagefill - 0) * (0.8 - 0.15)) / (1 - 0)) + 0.15;
        //newrange  0.1 - 0.8  //old range 0-1

            fillImage.fillAmount = (float)NewValue;

    }
}

