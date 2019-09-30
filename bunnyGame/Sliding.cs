using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{

    public GameObject AngleCalculator;
    public GameObject flags;
    float angleBetwinForwardAndMovement;
    public float Slidingfactor;
    public bool fixedForward;
    public bool Linear;//false is sin
    [SerializeField]
    float dampValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //forward line
        Debug.DrawLine(this.transform.position, this.transform.position + -transform.forward * 3, Color.yellow);
        //draw velociry
        Debug.DrawLine(this.transform.position, this.transform.position + (GetComponent<Rigidbody>().velocity), Color.blue);
        angleBetwinForwardAndMovement = AngleCalculator.GetComponent<FindNormal>().FindAngleOfBetwin2Vectors(GetComponent<Rigidbody>().velocity, -transform.forward);
        flags.GetComponent<PlayerFlags>().AngleBetwinMovingAndForward = angleBetwinForwardAndMovement;

        Vector3 fixedmovement = GetComponent<MoveControll>().FixedForwardSlope;
        float anglebetwinfixedforwardslopeAndMovment = AngleCalculator.GetComponent<FindNormal>().FindAngleOfBetwin2Vectors(GetComponent<Rigidbody>().velocity, fixedmovement);
        if (Linear)
        {
            dampValue = angleBetwinForwardAndMovement / 180;
        }
        else
        {
            dampValue = Mathf.Abs(Mathf.Sin(angleBetwinForwardAndMovement));
        }
        
        if (!flags.GetComponent<PlayerFlags>().get_IsInTheAir()){

            if (!System.Single.IsNaN(-GetComponent<Rigidbody>().velocity.x) && !System.Single.IsNaN(-GetComponent<Rigidbody>().velocity.y) && !System.Single.IsNaN(-GetComponent<Rigidbody>().velocity.z))
            {
                if (fixedForward)
                {
                    GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity * dampValue * Slidingfactor, ForceMode.Force);
                }
                else
                {
                  
                    if (!System.Single.IsNaN((-(GetComponent<Rigidbody>().velocity) * dampValue * Slidingfactor).x) ||
                        !System.Single.IsNaN((-(GetComponent<Rigidbody>().velocity) * dampValue * Slidingfactor).y) ||
                        !System.Single.IsNaN((-(GetComponent<Rigidbody>().velocity) * dampValue * Slidingfactor).z))
                    {
                        GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity * dampValue * Slidingfactor, ForceMode.Force);
                    }
                }
            }
        }

    }
}
