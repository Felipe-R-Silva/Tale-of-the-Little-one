using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNormal : MonoBehaviour
{
    public GameObject FlagManager;

    public GameObject Plaeyrcontroller;
    public float timeBetwineachcheck;
    private bool timetodraw;

    Vector3 Normal;
    Vector3 Up;
    Vector3 forward;

    public GameObject redBall; // drag in
    public GameObject blueBall; // drag in
    public GameObject blackBall; // drag in

    private void Start()
    {
        timetodraw = false;
           StartCoroutine(CheckCollision(callBack => {
               timetodraw = callBack;


        }, timeBetwineachcheck));
    }
    private void Update()
    {
       // transform.Translate(Vector3.forward*2 * Time.deltaTime);
        Debug.DrawLine(this.transform.position, this.transform.position + transform.up, Color.red);
    }
   

    void OnCollisionStay(Collision C)
    {
        if (C.transform.tag == "Ground" && timetodraw)
        {
            FlagManager.GetComponent<PlayerFlags>().set_IsInTheAir(false);
            timetodraw = false;
            for (int i = 0; i < C.contacts.Length; i++)
            {
                GameObject g = Instantiate(redBall, C.contacts[i].point, transform.rotation);
                Destroy(g, 1.0f); // so they don't clutter up the scene
                Normal = C.contacts[i].normal;
                Up = transform.up ;
                forward = -transform.forward;

                
                //Forward
                //Debug.DrawLine(this.transform.position, this.transform.position + transform.forward, Color.yellow,10f);
                //Normal
                Debug.DrawLine(transform.position, transform.position + C.contacts[i].normal, Color.black,1f);

                //Angle betwin forward and Normal
                float Angle = FindAngleOfBetwin2Vectors(Normal, forward);
                //rotate forwardso it is always paralel to the slope
                Vector3 fixedposition = RotateVector(Normal, forward, 90-Angle);
                //drawfinal result (holly shit I cant belive thsi is working)
                Debug.DrawLine(transform.position, transform.position + fixedposition*2, Color.magenta, 1f);
                //print Angle with ground
                //print("Angle:"+(Angle-90));
                //send to player
                Plaeyrcontroller.GetComponent<MoveControll>().FixedForwardSlope = RotateVector(Normal, forward, 90 - Angle);

                //calculate reversemode
                fixedposition = RotateVector(Normal, -forward, 90 - Angle);
                Plaeyrcontroller.GetComponent<MoveControll>().FixedBackwardsSlope = RotateVector(Normal, -forward, 90 - Angle);
            }
        }
    }

    public float FindAngleOfBetwin2Vectors(Vector3 vectorOne, Vector3 vectorTwo)
    {
        //Get Magnitude of Vectors
        float MagnitudeOne = FindMagnitude(vectorOne);
        //print("MagnitudeOne :" + MagnitudeOne);
        float MagnitudeTwo = FindMagnitude(vectorTwo);
        //print("MagnitudeTwo :" + MagnitudeTwo);
        //find dot product
        float Dotpord = FindDotProduct(vectorOne, vectorTwo);
        //print("Dotpord :" + Dotpord);
        //find cossine
        float cossin = FindCosine(MagnitudeOne, MagnitudeTwo, Dotpord);
        //print("cossin :" + cossin);
        //find angle rads??
        float radian = FindAnglewithcossine(cossin);
        //print("radian :" + radian);
        //fing angle degree
        float angle = FindAnglewithRadians(radian);
        //print("angle :" + angle);

        return angle;
    }

    public float FindMagnitude(Vector3 target)
    {
        //magnitude formula
        float Magnitude = Mathf.Sqrt(Mathf.Pow(target.x, 2) + Mathf.Pow(target.y, 2) + Mathf.Pow(target.z, 2));
        return Magnitude;
    }
    public float FindDotProduct(Vector3 vectorOne, Vector3 vectorTwo)
    {
        //magnitude formula
        float DotProduct = (vectorOne.x * vectorTwo.x) + (vectorOne.y * vectorTwo.y) + (vectorOne.z * vectorTwo.z);
        return DotProduct;
    }
    public float FindCosine(float MagnitudeOne, float MagnitudeTwo,float DotProduct)
    {
        //magnitude formula
        float CossinTheta = DotProduct / (MagnitudeOne* MagnitudeTwo);
        return CossinTheta;
    }
    public float FindAnglewithcossine(float cossin)
    {
        return Mathf.Acos(cossin);
        //magnitude formula
    }
    public float FindAnglewithRadians(float radians)
    {
        float angle;
        angle = (radians * 180) / Mathf.PI;

        return angle;
        //magnitude formula
    }
    public Vector3 RotateVector(Vector3 vectorOne, Vector3 vectorTwo, float angle)
    {
        //CrossProduct normal and forward
        Vector3 Crossporduct = Vector3.Cross(vectorOne, vectorTwo).normalized;
        //rotatess forward in the axis of the crossproduct
        Vector3 vector = Quaternion.AngleAxis(angle, Crossporduct) * vectorTwo;
        return vector;
    }
    IEnumerator CheckCollision(System.Action<bool> callBack,float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            callBack(true);
        }
    }


    //fixing flags for player flags
    void OnCollisionExit(Collision C)
    {
        if (C.transform.tag == "Ground")
        {
            FlagManager.GetComponent<PlayerFlags>().set_IsInTheAir(true);
        }
    }
    void OnCollisionEnter(Collision C)
    {
        if (C.transform.tag == "Ground")
        {
            FlagManager.GetComponent<PlayerFlags>().set_IsInTheAir(false);
        }
    }

}
