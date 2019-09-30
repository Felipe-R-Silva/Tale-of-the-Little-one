using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCameraCOntroll : MonoBehaviour
{
    LayerMask layerMask ;
    public float sensitivity;
    public float distance;
    float curentdistance;
    [SerializeField]
    float desireddistance;
    public float cameraLerpsensitivity;//betwin 0 and 1
    public float characterhighttreshhold;
    public bool PlayerIsbeingBlock;//check if camera is behind obstacle

    public Transform target;
    public Vector2 input;

    [Header("Debug Variables")]
    [SerializeField]
    public GameObject CameraToObject;
    [SerializeField]
    public GameObject ObjectToCamera;
    public Vector3 desiredPosition;
    // Start is called before the first frame update
    void Start()
    {
        //layerMask = ~((1 << 2) | (1 << 13));
        layerMask = ~((1 << LayerMask.NameToLayer("IgnorePlayer")) | (1 << LayerMask.NameToLayer("Ignore Raycast"))); // ignore collisions with layerX
        PlayerIsbeingBlock = false;
        
        
        sensitivity = 3;//Controller
        //sensitivity = 8;//Mouse
        curentdistance = distance;

    }

    // Update is called once per frame
    void Update()
    {
        //  Moving Camera with keyboard/Mouse ✔
        if (GUN.PlayerMaster.Instance.KeyboardMouse)
        {
            if (GUN.PlayerMaster.Instance.AxisControlls.ContainsKey(KEYS.ControllsKeyboardMouse.Instance.Camera))
            {
                string Xvalue = GUN.PlayerMaster.Instance.AxisControlls[KEYS.ControllsKeyboardMouse.Instance.Camera].X;
                string Yvalue = GUN.PlayerMaster.Instance.AxisControlls[KEYS.ControllsKeyboardMouse.Instance.Camera].Y;

                input += new Vector2((Input.GetAxis(Xvalue)) * sensitivity, -Input.GetAxis(Yvalue) * sensitivity);//Controller
            }
            else
            {
                // Requested a Axis Movement with a Button Key
                Debug.LogError("Error Player Is requesting A button Key to work as AxisKey: This function Is not Implemented");
            }
        }
        else
        {   //Moving Camera with controller ✔
            if (GUN.PlayerMaster.Instance.AxisControlls.ContainsKey(KEYS.ControllsController.Instance.Camera))
            {
                string Xvalue = GUN.PlayerMaster.Instance.AxisControlls[KEYS.ControllsController.Instance.Camera].X;
                string Yvalue = GUN.PlayerMaster.Instance.AxisControlls[KEYS.ControllsController.Instance.Camera].Y;

                input += new Vector2((Input.GetAxis(Xvalue)) * sensitivity, Input.GetAxis(Yvalue) * sensitivity);//Controller
            }
            else
            {
                // Requested a Axis Movement with a Button Key
                Debug.LogError("Error Player Is requesting A button Key to work as AxisKey: This function Is not Implemented");
            }
        }
        Quaternion rotation = Quaternion.Euler(input.y, input.x, 0);
        Vector3  desiredPosition = new Vector3( target.position.x, target.position.y + characterhighttreshhold, target.position.z) - (rotation * Vector3.forward * curentdistance);
        //rotation from player
        transform.localRotation = rotation;
        //Direct desired position
        transform.position = desiredPosition;
        //lerp Position
        //transform.position = smoothedPosition;


        
        var dir = target.transform.position - Camera.main.transform.position;

        /*
        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.transform.position, dir, out hitInfo, 1000))
        {
            //DrawRayAndCollisionPoint(Camera.main.transform.position, dir, hitInfo, CameraToObject);
        }
        */

        RaycastHit hitInfo2;
        Vector3 placeCamerashouldbe;
        
        if (Physics.Raycast(target.transform.position, -dir, out hitInfo2, curentdistance, layerMask))
        {
            //DrawRayAndCollisionPoint(target.transform.position, -dir, hitInfo2, ObjectToCamera);
            if (hitInfo2.transform.gameObject.tag != "Player")
            {
                PlayerIsbeingBlock = true;
                //try to avoid camera cliping true the wall
                if (hitInfo2.point.y < target.transform.position.y)
                {
                    placeCamerashouldbe = new Vector3(hitInfo2.point.x, target.transform.position.y, hitInfo2.point.z) + dir.normalized;
                    desireddistance = Vector3.Distance(new Vector3(hitInfo2.point.x, target.transform.position.y, hitInfo2.point.z), target.transform.position);
                }
                else
                {
                    placeCamerashouldbe = hitInfo2.point + dir.normalized;
                    desireddistance = Vector3.Distance(hitInfo2.point, target.transform.position);
                }
            }
        }
        else
        {
            if (!(Physics.Raycast(target.transform.position, -dir, out hitInfo2, distance, layerMask)))
            {
                    desireddistance = distance;
                    PlayerIsbeingBlock = false;
            }
            else
            {
                if (hitInfo2.transform.gameObject.tag != "Player")
                {
                    PlayerIsbeingBlock = true;
                    //try to avoid camera cliping true the wall
                    if (hitInfo2.point.y < target.transform.position.y)
                    {
                        placeCamerashouldbe = new Vector3(hitInfo2.point.x, target.transform.position.y, hitInfo2.point.z) + dir.normalized;
                        desireddistance = Vector3.Distance(new Vector3(hitInfo2.point.x, target.transform.position.y, hitInfo2.point.z), target.transform.position);
                    }
                    else
                    {
                        placeCamerashouldbe = hitInfo2.point + dir.normalized;
                        desireddistance = Vector3.Distance(hitInfo2.point, target.transform.position);
                    }
                }
            }

        }
        //lerp curent distance to desired distance
        //print(desireddistance);
        curentdistance=lerpdistance(curentdistance, desireddistance, cameraLerpsensitivity);
    }
    public void DrawRayAndCollisionPoint(Vector3 Startposition,Vector3 Direction, RaycastHit Hit,GameObject Marker) {

        Debug.DrawRay(Startposition, Direction, Color.red);
        if (Hit.transform.gameObject.tag != "Player")
        {
            GameObject g = Instantiate(Marker, Hit.point, Quaternion.identity);
            Destroy(g, 1f);
            //Destroy(hitInfo.transform.gameObject);
        }
    }

    float lerpdistance(float currentDistance,float DesiredDistance,float sensitivity)
    {
        // animate the position of the game object...
        return Mathf.Lerp(currentDistance, DesiredDistance, sensitivity * Time.deltaTime);


    }
}
