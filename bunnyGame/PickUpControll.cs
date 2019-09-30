using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PickUpControll : MonoBehaviour {

    // Use this for initialization

    private GameObject player;
    [SerializeField]
    private GameObject TrowPoint;
    [SerializeField]
    float trowDelay;
    [SerializeField]
    bool readytotrow;
    [SerializeField]
    Vector3 direction;

    [SerializeField]
    public bool CanPickup;
    [SerializeField]
    public bool IamHoldingItem;
    [SerializeField]
    public static GameObject MyItem;
    [SerializeField]
    private float TrowForece;
    [SerializeField]
    public Vector3 HowMuchOverhead= Vector3.zero;



    void Start()
    {
        readytotrow = false;
        player = transform.root.gameObject;
        CanPickup = false;
        IamHoldingItem = false;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(player.transform.position, TrowPoint.transform.position, Color.red);

        direction = TrowPoint.transform.position - player.transform.position;

        if (GUN.PlayerMaster.Instance.KeyboardMouse)
        {
            ReleasePickup();
        }
        else
        {
            ReleasePickupController();
        }
    }
    public void ReleasePickup()
    {
        
        if (Input.GetButtonDown(KEYS.ControllsKeyboardMouse.Instance.PickUp) && IamHoldingItem == true && readytotrow == true)
        {

            readytotrow = false;
            print("keyrelase");
            CanPickup = true;
            IamHoldingItem = false;

            if (MyItem.transform.name == "Cart")
            {
                MyItem.GetComponent<FolowCart>().enabled = false;
                player.GetComponent<RotateCode>().enabled = true;
                player.GetComponent<PlayerController>().SlideON = false;

            }
            else
            {
                MyItem.GetComponent<Rigidbody>().isKinematic = false;
                MyItem.GetComponent<Rigidbody>().detectCollisions = true;
                TrowPoint.SetActive(false);
                //GOone.parent = GOtwo; //GOone is now the child of GOtwo
                //other.gameObject.transform.parent = null;
                MyItem.transform.SetParent(null);
                MyItem.GetComponent<Rigidbody>().AddForce((direction * TrowForece) + this.transform.root.gameObject.GetComponent<Rigidbody>().velocity, ForceMode.Impulse);
            }
            //remove object from list
            PickUpControll.MyItem = null;
        }
    }
    public void ReleasePickupController()
    {
        if (!Input.GetButtonDown(KEYS.ControllsController.Instance.PickUp) && IamHoldingItem == true)
        {

            print("keyrelase");
            CanPickup = true;
            IamHoldingItem = false;

            if (MyItem.transform.name == "Cart")
            {
                MyItem.GetComponent<FolowCart>().enabled = false;
                player.GetComponent<RotateCode>().enabled = true;
                player.GetComponent<PlayerController>().SlideON = false;

            }
            else
            {
                MyItem.GetComponent<Rigidbody>().isKinematic = false;
                MyItem.GetComponent<Rigidbody>().detectCollisions = true;
                TrowPoint.SetActive(false);
                //GOone.parent = GOtwo; //GOone is now the child of GOtwo
                //other.gameObject.transform.parent = null;
                MyItem.transform.SetParent(null);
                MyItem.GetComponent<Rigidbody>().AddForce((direction * TrowForece) + this.transform.root.gameObject.GetComponent<Rigidbody>().velocity, ForceMode.Impulse);
            }
            //remove object from list
            PickUpControll.MyItem = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (GUN.PlayerMaster.Instance.KeyboardMouse)
        {
            PickUp(other);
        }
        else
        {
            PickUpController(other);
        }
    }
    public void PickUp(Collider other)
    {
        if (other.gameObject.tag == "Colectable")
        {
            //print("canColect");
            if (IamHoldingItem == false)
            {
                //print("set CanPickupt to true");
                CanPickup = true;
            }
            if (Input.GetButtonDown(KEYS.ControllsKeyboardMouse.Instance.PickUp) && CanPickup == true)
            {
                //Start coorotine that will reset CD
                StartCoroutine(trowCD((callback) => {
                    readytotrow = true;
                }, trowDelay));

                print("Grabed Item");
                IamHoldingItem = true;
                CanPickup = false;

                    //GOone.parent = GOtwo; //GOone is now the child of GOtwo
                    other.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));//zero rotation
                    other.gameObject.transform.parent = this.gameObject.transform;//parent to object
                    MyItem = other.gameObject;//assin to variable
                    MyItem.transform.localPosition = HowMuchOverhead;//place on top of head
                    TrowPoint.SetActive(true);

                    MyItem.GetComponent<Rigidbody>().isKinematic = true;//disable rigidbody
                    MyItem.GetComponent<Rigidbody>().detectCollisions = false;//disable boxcolider

            }


        }
        else
        {
            CanPickup = false;
        }
        //place On top of head
        //other.GetComponent<Rigidbody>().AddForce(direction * Atackforce, ForceMode.Impulse);
    }
    public void PickUpController(Collider other)
    {
        if (other.gameObject.tag == "Colectable")
        {
            //print("canColect");
            if (IamHoldingItem == false)
            {
                //print("set CanPickupt to true");
                CanPickup = true;
            }
            if (Input.GetButtonDown(KEYS.ControllsController.Instance.PickUp) && CanPickup == true)
            {

                print("key press");
                IamHoldingItem = true;
                CanPickup = false;
                
                    //GOone.parent = GOtwo; //GOone is now the child of GOtwo
                    other.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    other.gameObject.transform.parent = this.gameObject.transform;
                    MyItem = other.gameObject;
                    MyItem.transform.localPosition = HowMuchOverhead;
                    TrowPoint.SetActive(true);

                    MyItem.GetComponent<Rigidbody>().isKinematic = true;
                    MyItem.GetComponent<Rigidbody>().detectCollisions = false;
                

            }


        }
        else
        {
            CanPickup = false;
        }
        //place On top of head
        //other.GetComponent<Rigidbody>().AddForce(direction * Atackforce, ForceMode.Impulse);
    }

    IEnumerator trowCD(System.Action<bool> callback, float CDtime)
    {
        yield return new WaitForSeconds(CDtime);
        callback(false);
    }
}
