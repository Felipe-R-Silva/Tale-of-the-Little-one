using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParts : MonoBehaviour
{
    public GameObject[] Engines;
    public GameObject[] Nitros;
    public GameObject[] Weapons;
    public GameObject[] Jumpers;
    public GameObject[] Tires;

    private void Awake()
    {
        //Engine
        for(int i=0;i< Engines.Length; i++)
        {
            //checks what the player has on master and turns on or off
            bool EngineFlag = GUN.PlayerMaster.Instance.gameObject.GetComponent<CarPartsFlags>().Engines[i];
            Engines[i].SetActive(EngineFlag);   
        }
        //Nitro
        for (int i = 0; i < Nitros.Length; i++)
        {
            //checks what the player has on master and turns on or off
            bool NitroFlag = GUN.PlayerMaster.Instance.gameObject.GetComponent<CarPartsFlags>().Nitros[i];
            Nitros[i].SetActive(NitroFlag);
        }
        //Weapon
        for (int i = 0; i < Weapons.Length; i++)
        {
            //checks what the player has on master and turns on or off
            bool WeaponFlag = GUN.PlayerMaster.Instance.gameObject.GetComponent<CarPartsFlags>().Weapons[i];
            Weapons[i].SetActive(WeaponFlag);
        }
        //Jumper
        for (int i = 0; i < Jumpers.Length; i++)
        {
            //checks what the player has on master and turns on or off
            bool JumperFlag = GUN.PlayerMaster.Instance.gameObject.GetComponent<CarPartsFlags>().Jumpers[i];
            Jumpers[i].SetActive(JumperFlag);
        }
        //Tires
        for (int i = 0; i < Tires.Length; i++)
        {
            //checks what the player has on master and turns on or off
            bool TireFlag = GUN.PlayerMaster.Instance.gameObject.GetComponent<CarPartsFlags>().Tires[i];
            Tires[i].SetActive(TireFlag);
        }
    }
}
