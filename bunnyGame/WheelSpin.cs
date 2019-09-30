using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    float carSpeed;
    GameObject Car;
    public Transform parent;
    public float revolutionParameter;
    // Start is called before the first frame update
    public float smooth = 1f;
    private Quaternion targetRotation;
    void Start()
    {
        Car = this.transform.root.gameObject;
        targetRotation = transform.rotation;
    }

    void Update()
    {
        carSpeed = UpdateCarMagnitudeSpeed(Car);
        if (carSpeed>0.1)
        {
            transform.RotateAround(parent.position, transform.forward, carSpeed* revolutionParameter * Time.deltaTime);
        }
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
}
