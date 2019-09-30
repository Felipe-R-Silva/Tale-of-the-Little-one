using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public bool atacking;
    public float atackCD;
    public float bulletSpeed;
    public float destroytime;
    public GameObject bullet;
    public GameObject spawpoint;
    public float damage;

    public string Atackey;
    void Start()
    {
        atacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GUN.PlayerMaster.Instance.KeyboardMouse)
        {
            
            atack();//pc
        }
        else
        {
            atackController();//controller
        }
    }

    public void atack()
    {
        if (Input.GetButtonDown(KEYS.ControllsKeyboardMouse.Instance.Atack) && atacking == false)
        {
            print("I am in Here");
            atacking = true;
            StartCoroutine(Example(atackCD, ((Callback) =>
            {
                atacking = Callback;
            })));
            GameObject g = Instantiate(bullet, spawpoint.transform.position, transform.rotation);
            if (GetComponent<PlayerFlags>().get_IsInTheAir())
            {
                g.GetComponent<Rigidbody>().AddForce(-GetComponent<MoveControll>().transform.forward * bulletSpeed, ForceMode.Impulse);
            }
            else
            {
                g.GetComponent<Rigidbody>().AddForce(GetComponent<MoveControll>().FixedForwardSlope * bulletSpeed, ForceMode.Impulse);
            }
            Destroy(g, destroytime);
        }
    }
    public void atackController()
    {
        if (Input.GetButtonDown(KEYS.ControllsController.Instance.Atack) && atacking == false)
        {
            atacking = true;
            StartCoroutine(Example(atackCD, ((Callback) =>
            {
                atacking = Callback;
            })));
            GameObject g = Instantiate(bullet, spawpoint.transform.position, transform.rotation);
            if (GetComponent<PlayerFlags>().get_IsInTheAir())
            {
                g.GetComponent<Rigidbody>().AddForce(-GetComponent<MoveControll>().transform.forward * bulletSpeed, ForceMode.Impulse);
            }
            else
            {
                g.GetComponent<Rigidbody>().AddForce(GetComponent<MoveControll>().FixedForwardSlope * bulletSpeed, ForceMode.Impulse);
            }
            Destroy(g, destroytime);
        }
    }
    IEnumerator Example(float atackCD , System.Action<bool> atacking)
    {
        yield return new WaitForSeconds(atackCD);
        atacking(false);
    }
    

}
