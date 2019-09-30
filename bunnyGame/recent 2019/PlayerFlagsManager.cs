using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlagsManager : MonoBehaviour {

    public GameObject scamera;
    public GameObject player;
    public GameObject pickUp;
    public void FixedUpdate()
    {
        //Controlls
        player.GetComponent<PlayerFlags>().update_MovmentControllsActive(player);
        player.GetComponent<PlayerFlags>().update_CameraControllsActive(scamera.transform.root.gameObject);
        player.GetComponent<PlayerFlags>().update_AttackControllsActive(player);
        player.GetComponent<PlayerFlags>().update_pickUpControllsActive(pickUp);
        


        //Movment
        //player.GetComponent<PlayerFlags>().update_IsInTheAir(player);//FindNormals is updating this flag
        player.GetComponent<PlayerFlags>().update_IsFalling(player);
        player.GetComponent<PlayerFlags>().update_IsDoingFlipAttack(player);

        //PickUp
        player.GetComponent<PlayerFlags>().update_IsInRangeOfColectable(pickUp);
        player.GetComponent<PlayerFlags>().update_IsHoldingSomething(pickUp);


    }
}
