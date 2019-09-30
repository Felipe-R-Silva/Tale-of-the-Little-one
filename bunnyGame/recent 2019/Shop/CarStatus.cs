using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CarStatus
{
    [Header("Engine")]
    public string EngineName;
    public float EngineMaxSpeed;
    [Header("Nitro")]
    public bool HasNitro;
        public string NitroName;
        public float NitroMaxSpeed;
        public float NitroConsume;
        public float NitroChargeSpeed;
    [Header("Weapon")]
    public bool HasWeapon;
        public string WeaponName;
        public float WeaponPower;
        public float WeaponRange;
        public float WeaponFireRate;
    [Header("Jump")]
    public bool HasJump;
        public string JumpName;
        public float JumpPower;
    [Header("Tires")]
    public string TireName;
    public float TireControll;
}