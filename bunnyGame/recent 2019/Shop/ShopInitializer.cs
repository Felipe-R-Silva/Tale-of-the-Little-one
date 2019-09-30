using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInitializer : MonoBehaviour
{
    public Text Mymoney;
    public int currentMoney;
    public GameObject shopManager;
    public Text MyCurrentEquips;


    private void Awake()
    {
        shopManager.GetComponent<ShopManager>().shopCartItems = GUN.PlayerMaster.Instance.MyCartItems;
        Mymoney.text = GUN.PlayerMaster.Instance.Money.ToString();
        currentMoney = GUN.PlayerMaster.Instance.Money;
        MyCurrentEquips.text = "Engine :" + shopManager.GetComponent<ShopManager>().shopCartItems.EngineName.ToString() +
                             "\n Jump :" + shopManager.GetComponent<ShopManager>().shopCartItems.JumpName.ToString() +
                             "\n Nitro :" + shopManager.GetComponent<ShopManager>().shopCartItems.NitroName.ToString() +
                             "\n Tire :" + shopManager.GetComponent<ShopManager>().shopCartItems.TireName.ToString() +
                             "\n Weapon :" + shopManager.GetComponent<ShopManager>().shopCartItems.WeaponName.ToString();


        //Initialize fillBars
        InitializeFillBars(shopManager.GetComponent<FillBarsRefsUpdates>(),ref shopManager.GetComponent<ShopManager>().shopCartItems);
        //float EngineSpeedFillAmount=shopManager.GetComponent<FillBarsRefsUpdates>().ConvertValueToNewRange(shopManager.GetComponent<ShopManager>().shopCartItems.EngineMaxSpeed,20,10,1,0.1f);
        //shopManager.GetComponent<FillBarsRefsUpdates>().EngineSpeed.fillAmount = EngineSpeedFillAmount;
    }

    public void InitializeFillBars(FillBarsRefsUpdates fillsToUpdate,ref CarStatus CurrentStatus )
    {
        //Engine Speed
        float EngineSpeedFillAmount = fillsToUpdate.ConvertValueToNewRange(CurrentStatus.EngineMaxSpeed, fillsToUpdate.EngineSpeedRange.x, fillsToUpdate.EngineSpeedRange.y, 0.1f, 1);
        shopManager.GetComponent<FillBarsRefsUpdates>().EngineSpeed.fillAmount = Mathf.Abs(EngineSpeedFillAmount);

        //Nitro Power/speed
        float NitroPowerFillAmount = fillsToUpdate.ConvertValueToNewRange(CurrentStatus.NitroMaxSpeed, fillsToUpdate.NitroPowerRange.x, fillsToUpdate.NitroPowerRange.y, 0.1f, 1);
        shopManager.GetComponent<FillBarsRefsUpdates>().NitroPower.fillAmount = Mathf.Abs(NitroPowerFillAmount);
        //Nitro Consume (invertednumbers)
        float NitroConsumeFillAmount = fillsToUpdate.ConvertValueToNewRange(CurrentStatus.NitroConsume, fillsToUpdate.NitroConsumeRange.y, fillsToUpdate.NitroConsumeRange.x, 0.1f, 1);
        shopManager.GetComponent<FillBarsRefsUpdates>().NitroConsume.fillAmount = 1-Mathf.Abs(NitroConsumeFillAmount);
        //Nitro Reload
        float NitroReloadFillAmount = fillsToUpdate.ConvertValueToNewRange(CurrentStatus.NitroChargeSpeed, fillsToUpdate.NitroReloadRange.x, fillsToUpdate.NitroReloadRange.y, 0.1f, 1);
        shopManager.GetComponent<FillBarsRefsUpdates>().NitroReload.fillAmount = Mathf.Abs( NitroReloadFillAmount);

        //Weapon Power
        float WeaponPowerFillAmount = fillsToUpdate.ConvertValueToNewRange(CurrentStatus.WeaponPower, fillsToUpdate.WeaponPowerRange.x, fillsToUpdate.WeaponPowerRange.y, 0.1f, 1);
        shopManager.GetComponent<FillBarsRefsUpdates>().WeaponPower.fillAmount = Mathf.Abs(WeaponPowerFillAmount);
        //Weapon Range
        float WeaponRangeFillAmount = fillsToUpdate.ConvertValueToNewRange(CurrentStatus.WeaponRange, fillsToUpdate.WeaponRangeRange.x, fillsToUpdate.WeaponRangeRange.y, 0.1f, 1);
        shopManager.GetComponent<FillBarsRefsUpdates>().WeaponRange.fillAmount = Mathf.Abs(WeaponRangeFillAmount);
        //Weapon Fire Rate (invertednumbers)
        float WeaponRireRateFillAmount = fillsToUpdate.ConvertValueToNewRange(CurrentStatus.WeaponFireRate, fillsToUpdate.WeaponFireRateRange.y, fillsToUpdate.WeaponFireRateRange.x, 0.1f, 1);
        shopManager.GetComponent<FillBarsRefsUpdates>().WeaponFireRate.fillAmount = 1-Mathf.Abs(WeaponRireRateFillAmount);

        //Jump Power
        float JumpPowerFillAmount = fillsToUpdate.ConvertValueToNewRange(CurrentStatus.JumpPower, fillsToUpdate.JumpPowerRange.x, fillsToUpdate.JumpPowerRange.y, 0.1f, 1);
        shopManager.GetComponent<FillBarsRefsUpdates>().JumpPower.fillAmount = Mathf.Abs(JumpPowerFillAmount);

        //Tires Controll
        float TiresControllFillAmount = fillsToUpdate.ConvertValueToNewRange(CurrentStatus.TireControll, fillsToUpdate.TiresControllRange.x, fillsToUpdate.TiresControllRange.y, 0.1f, 1);
        shopManager.GetComponent<FillBarsRefsUpdates>().TiresControll.fillAmount = Mathf.Abs(TiresControllFillAmount);
    }
}
