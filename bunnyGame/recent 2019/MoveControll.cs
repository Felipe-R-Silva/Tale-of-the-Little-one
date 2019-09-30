using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveControll : MonoBehaviour {
    
    public GameObject flagscript;
    public Vector3 FixedForwardSlope;
    public Vector3 FixedBackwardsSlope;
    [SerializeField]
    public float maxSpeed ;
    [SerializeField]
    private float aceleration;
    [SerializeField]
    public bool HasNitro;
    [SerializeField]
    public float maxSpeedNitro ;
    [SerializeField]
    private float NitroAceleration;
    [SerializeField]
    public float NitroCurrentAmount;//0-1
    [SerializeField]
    public float NitroConsumingSpeed;
    [SerializeField]
    public float NitroConsumeAmount;//0-1
    [SerializeField]
    public float NitroReloadSpeed;
    [SerializeField]
    public float NitroReloadAmount;
    [SerializeField]
    public Image NitroBar;
    [SerializeField]
    bool coorutineIsrunning;
    bool coorutinefillIsrunning;

    public Animator jumpLeg1;
    public Animator jumpLeg2;
    public GameObject NitroFX;



    [SerializeField]
    public Rigidbody rb;

    //Make sure you attach a Rigidbody in the Inspector of this GameObject
    public Vector3 RotationSpeed;
    public bool CanJump;
    public bool CanMove;
    public bool CanRotate;
    bool HasJump;
    public float JumpForce;
    public float JumpCDtime;

    //Particles
    [SerializeField]
    private GameObject Smoke_Jump;
    [SerializeField]
    private GameObject Smoke_hopWalk;

    [SerializeField]
    public Animator AnimationCtrl;

    public void Start()
    {
        InitializeCart();
        coorutineIsrunning = false;
        coorutinefillIsrunning = false;
        NitroCurrentAmount =1;
        //hide mouse first time
        Cursor.visible = false;//hide mouse
        Cursor.lockState = CursorLockMode.Locked;//lock mouse

        FixedForwardSlope = -transform.forward;


        rb.GetComponent<Rigidbody>();
    }
    public void Update()
    {
        //if playing with keyboard/Mouse
        if (GUN.PlayerMaster.Instance.KeyboardMouse)
        {
            //rotate player ✔
            if (CanRotate)
            {
                rotatePlayer(rb, RotationSpeed);//pc
            }
            //Move ✔ Acelerate ✔
            if (CanMove)
            {
                
                movePlayer(ref rb, aceleration, NitroAceleration);//pc
            }

            //Jump ✔
            if (CanJump)
            {
                jumpPlayer(JumpForce);
            }
        }
        else
        {
            //rotate player
            rotatePlayerCotroller(rb, RotationSpeed);//contorller
            //Move ✔ Acelerate✘
            movePlayerCotroller(ref rb, aceleration, NitroAceleration);//controller
            //Jump ✔
            jumpPlayerController(JumpForce);//controller
        }

        //For Any Controller

            //Animation sincronize
            animationcheck();
            //Update NitroBar ✔
            if (HasNitro)
            {
                NitroBar.fillAmount = NitroCurrentAmount;
            }
    }

    public void rotatePlayer(Rigidbody rb, Vector3 RotationSpeed)
    {
        //rotate right && check AxisKey
        if (Input.GetKey(KEYS.ControllsKeyboardMouse.Instance.Right) && CheckIfIsAxisKey(KEYS.ControllsKeyboardMouse.Instance.Right,false))
        {
            Quaternion deltaRotation = Quaternion.Euler(360 * RotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        //rotate left && check AxisKey
        if (Input.GetKey(KEYS.ControllsKeyboardMouse.Instance.Left) && CheckIfIsAxisKey(KEYS.ControllsKeyboardMouse.Instance.Right, false))
        {
            Quaternion deltaRotation = Quaternion.Euler(-360 * RotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

    }
    public void rotatePlayerCotroller(Rigidbody rb, Vector3 RotationSpeed)
    {
        if (CheckIfIsAxisKey(KEYS.ControllsController.Instance.RotateX, true))
        {
            string Xvalue = GUN.PlayerMaster.Instance.AxisControlls[KEYS.ControllsController.Instance.RotateX].X;
            string Yvalue = GUN.PlayerMaster.Instance.AxisControlls[KEYS.ControllsController.Instance.RotateX].Y;

            Vector2 Playerinput = new Vector2((Input.GetAxis(Xvalue)), -Input.GetAxis(Yvalue));
            //rotate right
            if (Playerinput.x > 0)
            {
                Quaternion deltaRotation = Quaternion.Euler(360 * RotationSpeed * Playerinput.x * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            //rotate left
            if (Playerinput.x < 0)
            {
                Quaternion deltaRotation = Quaternion.Euler(360 * RotationSpeed * Playerinput.x * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
        }

    }

    void movePlayer(ref Rigidbody rb, float speed,float speed2)
    {
        if (!GetComponent<PlayerFlags>().get_IsInTheAir())
        {
            //move forward
            if (Input.GetKey(KEYS.ControllsKeyboardMouse.Instance.Forward) && CheckIfIsAxisKey(KEYS.ControllsKeyboardMouse.Instance.Forward, false))
            {
                //saveOldSpeed
                Vector3 oldspeed = rb.velocity;
                AnimationCtrl.SetBool("Walking", true);
                //move
                //print("oldmagnitude: " + oldspeed.magnitude);
                if (oldspeed.magnitude<maxSpeed) {
                    rb.AddForce(FixedForwardSlope * speed, ForceMode.Force);
                }
                //max speed
                if (rb.velocity.magnitude > maxSpeed && !Input.GetKey(KEYS.ControllsKeyboardMouse.Instance.Acelerate))
                {
                    rb.velocity = oldspeed;
                }

            }
            if (HasNitro)
            {
                //acelerate
                if (Input.GetKey(KEYS.ControllsKeyboardMouse.Instance.Forward) && Input.GetKey(KEYS.ControllsKeyboardMouse.Instance.Acelerate) && CheckIfIsAxisKey(KEYS.ControllsKeyboardMouse.Instance.Acelerate, false))
                {
                    
                    
                    //consumeNitro
                    bool CanAcelerate = CallConsumeNitro();

                    if (CanAcelerate) {
                        
                        //saveOldSpeed
                        print("I am aceleration liek hell");
                        Vector3 oldspeed = rb.velocity;
                        AnimationCtrl.SetBool("Walking", true);
                        //move
                        if (oldspeed.magnitude < maxSpeedNitro)
                        {
                            //move
                            rb.AddForce(FixedForwardSlope * speed2, ForceMode.Force);

                        }
                        //max speed
                        if (rb.velocity.magnitude > maxSpeedNitro)
                        {
                            rb.velocity = oldspeed;
                        }
                    }
                }
                else// he is not acelerating
                {
                    //Nitro Animation Off
                    NitroFX.SetActive(false);
                    CallReloadNitro();
                }
            }
            //flags
            if (Input.GetKeyDown(KEYS.ControllsKeyboardMouse.Instance.Forward))
            {
                AnimationCtrl.SetBool("Walking", true);
            }
            if (Input.GetKeyUp(KEYS.ControllsKeyboardMouse.Instance.Forward))
            {
                AnimationCtrl.SetBool("Walking", false);
            }
            //moveback
            if (Input.GetKey(KEYS.ControllsKeyboardMouse.Instance.Backwards) && CheckIfIsAxisKey(KEYS.ControllsKeyboardMouse.Instance.Backwards, false))
            {
                //move back
                rb.AddForce(transform.forward * speed, ForceMode.Force);
            }
        }
        else
        {
            //Nitro Animation Off
            NitroFX.SetActive(false);
            CallReloadNitro();
            //forward In the Air
            if (Input.GetKeyDown(KEYS.ControllsKeyboardMouse.Instance.Forward))
            {
                rb.AddForce(-transform.forward * speed, ForceMode.Force);
            }
            //backwards In the Air
            if (Input.GetKey(KEYS.ControllsKeyboardMouse.Instance.Backwards) && CheckIfIsAxisKey(KEYS.ControllsKeyboardMouse.Instance.Backwards, false))
            {
                rb.AddForce(transform.forward * speed/5, ForceMode.Force);
            }

        }
    }

    void movePlayerCotroller(ref Rigidbody rb, float speed,float speed2)
    {
        string xValue = GUN.PlayerMaster.Instance.AxisControlls[KEYS.ControllsController.Instance.Forward].X;//forwaard R_Back trigger
        string yValue = GUN.PlayerMaster.Instance.AxisControlls[KEYS.ControllsController.Instance.Acelerate].Y;//acelerate L_Back trigger

        string backwards = GUN.PlayerMaster.Instance.AxisControlls[KEYS.ControllsController.Instance.Backwards].Y;//change this to something more reasonable
        Vector2 Playerinput = new Vector2((Input.GetAxis(xValue)), Input.GetAxis(yValue));

        if (!GetComponent<PlayerFlags>().get_IsInTheAir())
        {
            
            if (Playerinput.y>0)
            {
                //saveOldSpeed
                Vector3 oldspeed = rb.velocity;
                AnimationCtrl.SetBool("Walking", true);
                //move
                //print("oldmagnitude: " + oldspeed.magnitude);
                if (oldspeed.magnitude < maxSpeed)
                {
                    if (Playerinput.y > 0.8) Playerinput.y = 1;
                    rb.AddForce(FixedForwardSlope * speed * Playerinput.y + FixedForwardSlope * speed2 * Playerinput.x, ForceMode.Force);
                }
                //max speed
                if (rb.velocity.magnitude > maxSpeed +(maxSpeedNitro- maxSpeed)* Playerinput.x)
                {
                    rb.velocity = oldspeed;
                }

            }

            //flags
            if (Playerinput.y > 0.3)
            {
                AnimationCtrl.SetBool("Walking", true);
            }
            if (Playerinput.y < 0.3)
            {
                AnimationCtrl.SetBool("Walking", false);
            }
            //moveback
            if (Input.GetAxis(backwards)<0)//Dpad
            {
                //move back
                rb.AddForce(transform.forward * speed, ForceMode.Force);
            }
        }
        else
        {
            if (Playerinput.y > 0.8)
            {
                rb.AddForce(-transform.forward * speed / 30, ForceMode.Force);
            }
            if (Input.GetAxis(backwards) < 0)
            {
                rb.AddForce(transform.forward * speed / 5, ForceMode.Force);
            }

        }
    }

    void jumpPlayer(float jumpThrust)
    {
        if (!flagscript.GetComponent<PlayerFlags>().get_JumpOnCoolDown())
        {
            if (!GetComponent<PlayerFlags>().get_IsInTheAir())
            {
                //jump
                if (Input.GetKeyDown(KEYS.ControllsKeyboardMouse.Instance.Jump) && CheckIfIsAxisKey(KEYS.ControllsKeyboardMouse.Instance.Jump,false))
                {
                    //fx smoke jump
                    Instantiate(Smoke_Jump, this.transform.position, this.transform.rotation);
                    //set Jump CD
                    flagscript.GetComponent<PlayerFlags>().set_JumpOnCoolDown(true);
                    //Jump animation
                    jumpLeg1.SetBool("Jump", true);
                    jumpLeg2.SetBool("Jump", true);
                    //Start coorotine that will reset CD
                    StartCoroutine(JumpCD((callback) => { flagscript.GetComponent<PlayerFlags>().set_JumpOnCoolDown(callback); }, JumpCDtime));
                    //Jump
                    rb.AddForce(transform.up * jumpThrust);
                    
                    
                }
            }
        }
    }
   
    void jumpPlayerController(float jumpThrust)
    {
        if (!flagscript.GetComponent<PlayerFlags>().get_JumpOnCoolDown())
        {
            if (!GetComponent<PlayerFlags>().get_IsInTheAir())
            {
                if (Input.GetButtonDown(KEYS.ControllsController.Instance.Jump) && CheckIfIsAxisKey(KEYS.ControllsController.Instance.Jump, false))
                {
                    //fx smoke jump
                    Instantiate(Smoke_Jump, this.transform.position, this.transform.rotation);
                    //set Jump CD
                    flagscript.GetComponent<PlayerFlags>().set_JumpOnCoolDown(true);
                    //Jump animation
                    jumpLeg1.SetBool("Jump", true);
                    jumpLeg2.SetBool("Jump", true);
                    //Start coorotine that will reset CD
                    StartCoroutine(JumpCD((callback) => { flagscript.GetComponent<PlayerFlags>().set_JumpOnCoolDown(callback); }, JumpCDtime));
                    //Jump
                    rb.AddForce(transform.up * jumpThrust);
                }
            }
        }
    }
    //this is use to reset CD variable after X time
    IEnumerator JumpCD(System.Action<bool> callback,float CDtime)
    {
        yield return new WaitForSeconds(CDtime);
        callback(false);
    }
    IEnumerator ConsumeNITRO(System.Action<bool> NitroEND, float ConsumeAmount,float ConsumeSpeed, System.Action<bool> CorutineRunning)
    {
        CorutineRunning(true);
        if (NitroCurrentAmount < NitroConsumeAmount)
        {
            NitroEND(true);
            CorutineRunning(false);
            yield break;
        }
        yield return new WaitForSeconds(ConsumeSpeed);
        if (NitroCurrentAmount - NitroConsumeAmount<= 0)
        {
            NitroCurrentAmount = 0;
            NitroEND(true);
        }
        NitroEND(false);
        CorutineRunning(false);
    }
    public bool CallConsumeNitro()
    {
        bool CanAcelerate=true;
        //ConsumeNitroBar If there is any
        if (!coorutineIsrunning)
        {
            
            if (coorutinefillIsrunning)//reload coorotine cant run same time as the consume one
            {
                StopCoroutine("ReloadNitro");
            }
            StartCoroutine(ConsumeNITRO((NitroEND) =>
            {
                if (NitroEND == true)
                {
                    //Nitro Animation On
                    NitroFX.SetActive(false);
                    //No more Nitro To Use
                    CanAcelerate = false;
                    NitroCurrentAmount = 0;
                }
                else
                {
                    //Nitro Animation On
                    NitroFX.SetActive(true);
                    //Use Nitro To Speed Up
                    NitroCurrentAmount -= NitroConsumeAmount;
                    CanAcelerate = true;
                }
            }, NitroConsumeAmount, NitroConsumingSpeed, ((CorutineIsRunning) =>
            {
                coorutineIsrunning = CorutineIsRunning;
            })));
        }
        return CanAcelerate;
    }

        IEnumerator ReloadNitro(System.Action<bool> ReloadNitroRunning, float NitroReloadSpeed, float NitroReloadAmount)
    {

        ReloadNitroRunning(true);
        yield return new WaitForSeconds(NitroReloadSpeed);
        if(NitroCurrentAmount + NitroReloadAmount >= 1)
        {
            NitroCurrentAmount = 1;
        }
        ReloadNitroRunning(false);
    }

    public void CallReloadNitro() {
        print("not Acelerating");
        if (!coorutinefillIsrunning)
        {
            if (coorutineIsrunning)//stop consume coorutine if it is running at the same time as reload
            {
                StopCoroutine("ConsumeNITRO");
            }
            StartCoroutine(ReloadNitro((ReloadingNitro) =>
            {
                if (ReloadingNitro == true)
                {
                    coorutinefillIsrunning = true;

                }
                else
                {
                    if (NitroCurrentAmount + NitroReloadAmount > 1)
                    {
                        NitroCurrentAmount = 1;
                    }
                    NitroCurrentAmount += NitroReloadAmount;
                    coorutinefillIsrunning = false;
                }
            }, NitroReloadSpeed, NitroReloadAmount));
        }
    }
    public void animationcheck()
    {

        if (flagscript.GetComponent<PlayerFlags>().get_IsInTheAir())
        {
            AnimationCtrl.SetBool("Walking", false);
        }
    }
    public bool CheckIfIsAxisKey(string playerImput,bool IwhatItToBe)
    {
        if (GUN.PlayerMaster.Instance.AxisControlls.ContainsKey(playerImput))
        {   
            //I wanted it to be false but it is true
            if (!IwhatItToBe)
            {
                Debug.LogError("Error Player Is requesting A button Key to work as AxisKey: This function Is not Implemented");
                return false;
            }
            return true;
        }
        //I wanted it to be true but it is false
        if (IwhatItToBe)
        {
            Debug.LogError("Error Player Is requesting A button Key to work as AxisKey: This function Is not Implemented");
            return false;
        }
        return true;
    }
    public void InitializeCart()
    {
        CarStatus masterCarData = GUN.PlayerMaster.Instance.MyCartItems;
        //masterCarData.EngineName;
        maxSpeed = masterCarData.EngineMaxSpeed;
        HasNitro = masterCarData.HasNitro;
        //masterCarData.NitroName;
        maxSpeedNitro = masterCarData.NitroMaxSpeed;
        NitroConsumeAmount = masterCarData.NitroConsume;
        NitroReloadAmount = masterCarData.NitroChargeSpeed;
        //masterCarData.HasWeapon;
        //masterCarData.WeaponName;
        this.gameObject.GetComponent<Fire_bullet>().damage = masterCarData.WeaponPower;
        //this.gameObject.GetComponent<Fire_bullet>().??= masterCarData.WeaponRange;
        this.gameObject.GetComponent<Fire_bullet>().atackCD = masterCarData.WeaponFireRate;
        HasJump = masterCarData.HasJump;
        //masterCarData.JumpName;
        JumpForce = masterCarData.JumpPower;
        //masterCarData.TireName;
        this.gameObject.GetComponent<Sliding>().Slidingfactor = masterCarData.TireControll;
    }
    public void turnmovementOff()
    {
        CanMove = false;
    }
    public void turnmovementON()
    {
        CanMove = true;
    }
    public void turnJumptOff()
    {
        CanJump = false;
    }
    public void turnJumptON()
    {
        CanJump = true;
    }
    public void turnRotateOff()
    {
        CanRotate = false;
    }
    public void turnRotateON()
    {
        CanRotate = true;
    }
}
