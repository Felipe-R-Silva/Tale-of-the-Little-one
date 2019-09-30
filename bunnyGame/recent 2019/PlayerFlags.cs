using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlags : MonoBehaviour {

    //Define Up Down Right Left
    Vector3 up = Vector3.up;
    Vector3 down = Vector3.down;
    Vector3 left = Vector3.left;
    Vector3 right = Vector3.right;

    [Header("Controlls")]
    //Scripts

    [SerializeField]  private bool MovmentControllsActive; // lets you move player
    [SerializeField]  private bool CameraControllsActive; // lets you move camera
    [SerializeField]  private bool AttackControllsActive; // lets you Attack
    [SerializeField]  private bool pickUpControllsActive; // lets you pick Up Items
    //Movement
    [Header("Movement")]
    [SerializeField]  private bool JumpOnCoolDown;//IcanJumpAgain
    [SerializeField]  private bool IsInTheAir;//If the player is not touching the ground
    [SerializeField]  private bool IsFalling;//If the player is not touching the ground && he is acelerating down
    [SerializeField]  public bool IsCloseToEdge;//If the player is close to a pit
    [SerializeField]  public bool IsDoingFlipAttack;//If the plaeyr is doing a attack
    //Inventory
    [Header("Inventory")]
    [SerializeField]  private bool IsInRangeOfColectable;
    [SerializeField]  private bool IsHoldingSomething;
    [SerializeField]  public bool BackpackIsFull;

    //
    [SerializeField] public float AngleBetwinMovingAndForward;


    //--------------------------------------------------

    //Player Movement ControllerOn
    public bool get_MovmentControllsActive()
    {
        return MovmentControllsActive;
    }
    public void set_MovmentControllsActive(bool newState, GameObject player)
    {
        if( MovmentControllsActive != newState)//check If needs change
        {
            player.GetComponent<MoveControll>().enabled = newState;
            MovmentControllsActive = newState;
        }
    }
    public void update_MovmentControllsActive(GameObject player)
    {
        MovmentControllsActive = player.GetComponent<MoveControll>().isActiveAndEnabled;
    }


    //Camera ControllerOn
    public bool get_CameraControllsActive()
    {
        return CameraControllsActive;
    }
    public void set_CameraControllsActive(bool newState, GameObject camera)
    {
        if (MovmentControllsActive != newState)//check If needs change
        {
            camera.GetComponent<MoveControll>().enabled = newState;
            MovmentControllsActive = newState;
        }
    }
    public void update_CameraControllsActive(GameObject camera)
    {
        CameraControllsActive = camera.GetComponent<MSCameraController>().isActiveAndEnabled;
    }

    //Atack ControllerOn
    public bool get_AttackControllsActive()
    {
        return AttackControllsActive;
    }
    public void set_AttackControllsActive(bool newState, GameObject player)
    {
        if (AttackControllsActive != newState)//check If needs change
        {
            player.GetComponent<RotateCode>().enabled = newState;
            AttackControllsActive = newState;
        }

    }
    public void update_AttackControllsActive(GameObject player)
    {
        AttackControllsActive = player.GetComponent<RotateCode>().isActiveAndEnabled;
    }

    //PickUp ControllerOn
    public bool get_pickUpControllsActive()
    {
        return pickUpControllsActive;
    }
    public void set_pickUpControllsActive(bool newState, GameObject PickUpcoll)
    {
        if (pickUpControllsActive != newState)//check If needs change
        {
            PickUpcoll.GetComponent<PickUpControll>().enabled = newState;
            pickUpControllsActive = newState;
        }

    }
    public void update_pickUpControllsActive(GameObject PickUpcoll)
    {
        pickUpControllsActive = PickUpcoll.GetComponent<PickUpControll>().isActiveAndEnabled;
    }

    //JumpCooldown
   
    public bool get_JumpOnCoolDown()
    {
        return JumpOnCoolDown;
    }
    public void set_JumpOnCoolDown(bool newState)
    {
        if (JumpOnCoolDown != newState)//check If needs change
        {
            JumpOnCoolDown = newState;
        }
    }
    //In The Air
     public bool get_IsInTheAir()
    {
        return IsInTheAir;
    }
    public void set_IsInTheAir(bool newState)
    {
        if (IsInTheAir != newState)//check If needs change
        {
            IsInTheAir = newState;
        }
    }
    public void update_IsInTheAir( GameObject player ,float standingdistance = 0.6f)
    {

        RaycastHit hit;
        int distance = 10;
        Vector3 Rdirection = down;
        //edit: to draw ray also//
        Debug.DrawRay(transform.position, Rdirection * distance, Color.green);
        //end edit//
        if (Physics.Raycast(transform.position, Rdirection, out hit, distance))
        {
            //the ray collided with something, you can interact
            // with the hit object now by using hit.collider.gameObject
            if (hit.collider.tag == "Ground")
            {
                if (hit.distance < standingdistance)
                {
                    IsInTheAir = false;
                }
                else
                {
                    IsInTheAir = true;
                }
            }
        }
        else
        {
        //nothing was below your gameObject within 10m.
        }

    }

    
    //Is Falling
    public bool get_IsFallinge()
    {
        return IsFalling;
    }
    public void set_IsFalling(bool newState)
    {
        if (IsFalling != newState)//check If needs change
        {
            IsFalling = newState;
        }

    }
    public void update_IsFalling(GameObject player)
    {
        //StartCoroutine callback if it is falling
        StartCoroutine(Check_Vertical_translation
         ((myReturnValue) => 
            {
                set_IsFalling(myReturnValue);
            }
         ));
    }
    IEnumerator Check_Vertical_translation(System.Action<bool> callback)
    {
        float previousheight= transform.position.y;

        yield return new WaitForSeconds(0.01f);

        float currentheight = transform.position.y;
        float travel = currentheight - previousheight;
        if (Mathf.Abs(travel) > 0 && Mathf.Abs(travel) > 0.0001)
        {
            if (currentheight < previousheight)
            {
                //it is falling
                callback(true);
            }
            else
            {
                //it is NOT falling
                callback(false);
            }
        }
        else
        {
            callback(false);
            //it is NOT falling
        }
    }


    //IsCloseToEdge


    //Is doing Flip Attack
    public bool get_IsDoingFlipAttack()
    {
        return IsDoingFlipAttack;
    }
    public void set_IsDoingFlipAttack(bool newState)
    {
        if (IsDoingFlipAttack != newState)//check If needs change
        {
            IsDoingFlipAttack = newState;
        }
    }
    public void update_IsDoingFlipAttack(GameObject player)
    {
        IsDoingFlipAttack= player.GetComponent<RotateCode>().atacking;
    }

    //Is In Range Of Colectable
    public bool get_IsInRangeOfColectable()
        {
            return IsInRangeOfColectable;
        }
    public void set_IsInRangeOfColectable(bool newState)
    {
        if (IsInRangeOfColectable != newState)//check If needs change
        {
            IsInRangeOfColectable = newState;
        }
    }
    public void update_IsInRangeOfColectable(GameObject ColectColl)
    {
        IsInRangeOfColectable = ColectColl.GetComponent<PickUpControll>().CanPickup;
    }

    //Is Holding Something
    public bool get_IsHoldingSomething()
    {
        return IsHoldingSomething;
    }
    public void set_IsHoldingSomething(bool newState)
    {
        if (IsHoldingSomething != newState)//check If needs change
        {
            IsHoldingSomething = newState;
        }
    }
    public void update_IsHoldingSomething(GameObject ColectColl)
    {
        IsHoldingSomething = ColectColl.GetComponent<PickUpControll>().IamHoldingItem;
    }
}

