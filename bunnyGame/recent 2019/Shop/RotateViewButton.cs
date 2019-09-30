using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RotateViewButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public OrbitalCameraCOntroll_Arrow rotatecode;
    private bool pointerDown;
    public float CurrentValue_X;
    public float numberAddedOverTime_X;
    public float CurrentValue_Y;
    public float numberAddedOverTime_Y;
    public bool UseLimitsX;
    public bool UseLimitsY;
    public Vector2 MaxLimit;
    public Vector2 MinLimit;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
        Debug.Log("OnPointerUp");
    }

    // Update is called once per frame
    void Start()
    {
           pointerDown = false;
    }
    void FixedUpdate()
    {
        if (pointerDown)
        {
            //assign X
            CurrentValue_X = rotatecode.input.x;
            if (UseLimitsX == true)
            {
                if (CurrentValue_X + numberAddedOverTime_X < MaxLimit.x && CurrentValue_X + numberAddedOverTime_X > MinLimit.x)
                {
                    rotatecode.input.x += numberAddedOverTime_X * Time.deltaTime;
                }
            }
            else
            {
                rotatecode.input.x += numberAddedOverTime_X * Time.deltaTime;
            }
            //assign Y
            
            CurrentValue_Y = rotatecode.input.y;
            if (UseLimitsY == true)
            {
                if (CurrentValue_Y + numberAddedOverTime_Y * Time.deltaTime < MaxLimit.y && CurrentValue_Y + numberAddedOverTime_Y * Time.deltaTime > MinLimit.y)
                {
                    rotatecode.input.y += numberAddedOverTime_Y * Time.deltaTime;
                }
            }
            else
            {
                rotatecode.input.y += numberAddedOverTime_Y * Time.deltaTime;
            }
        }

    }
}
