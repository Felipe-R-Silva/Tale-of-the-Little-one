using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBarsRefsUpdates : MonoBehaviour
{
    //Engine
    public Image EngineSpeed;
    public Vector2 EngineSpeedRange;
    //Nitro
    public Image NitroPower;
    public Vector2 NitroPowerRange;
    public Image NitroConsume;
    public Vector2 NitroConsumeRange;
    public Image NitroReload;
    public Vector2 NitroReloadRange;
    //Weapon
    public Image WeaponPower;
    public Vector2 WeaponPowerRange;
    public Image WeaponRange;
    public Vector2 WeaponRangeRange;
    public Image WeaponFireRate;
    public Vector2 WeaponFireRateRange;
    //Jump
    public Image JumpPower;
    public Vector2 JumpPowerRange;
    //Tires
    public Image TiresControll;
    public Vector2 TiresControllRange;

    //Example ConvertValueToNewRange(10,50,1,1,0.1)
    public float ConvertValueToNewRange(float OldValue , float OldMin , float OldMax, float NewMin, float NewMax)
    {
        if(OldValue> OldMax)
        {
            OldValue = OldMax;
            return 1;
        }
        if (OldValue < OldMin)
        {
            OldValue = OldMin;
            return 0;
        }
        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
        return NewValue;
    }
}
