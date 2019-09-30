using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public GameObject ShopManagerRef;
    public Text PriceTag;
    public int CurrentItemPrice;
   // delegate void MyDelegate<T>(T value);

    private void Start()
    {
    }
    public void RubberTire()
    {
        //initialize->reset
        CarStatus newcar = ShopManagerRef.GetComponent<ShopManager>().shopCartItems;
        //draw fillbars
        ShopManagerRef.GetComponent<ShopInitializer>().InitializeFillBars(ShopManagerRef.GetComponent<FillBarsRefsUpdates>(), ref GUN.PlayerMaster.Instance.MyCartItems);

        //change specific values
        newcar.TireControll = 8;
        //set shopItems to be equal to new 
        ShopManagerRef.GetComponent<ShopManager>().shopCartItems = newcar;
        //change fillbars
        ShopManagerRef.GetComponent<ShopInitializer>().InitializeFillBars(ShopManagerRef.GetComponent<FillBarsRefsUpdates>(), ref newcar);
        //changeDisplayValue
        int price = 10;//**************
        PriceTag.text = (price).ToString();
        CurrentItemPrice = price;
    }
    public void WagonTire()
    {
        //initialize->reset
        CarStatus newcar = ShopManagerRef.GetComponent<ShopManager>().shopCartItems;
        //draw fillbars
        ShopManagerRef.GetComponent<ShopInitializer>().InitializeFillBars(ShopManagerRef.GetComponent<FillBarsRefsUpdates>(), ref GUN.PlayerMaster.Instance.MyCartItems);

        //change specific values
        newcar.TireControll = 3;
        //set shopItems to be equal to new 
        ShopManagerRef.GetComponent<ShopManager>().shopCartItems = newcar;
        //change fillbars
        ShopManagerRef.GetComponent<ShopInitializer>().InitializeFillBars(ShopManagerRef.GetComponent<FillBarsRefsUpdates>(), ref newcar);
        //changeDisplayValue
        int price=0;//**************
        PriceTag.text = (price).ToString();
        CurrentItemPrice = price;
    }
    public void PurchaseItem()
    {
        //change local money value
        this.gameObject.GetComponent<ShopInitializer>().currentMoney -= CurrentItemPrice;
        //change local money text
        this.gameObject.GetComponent<ShopInitializer>().Mymoney.text = this.gameObject.GetComponent<ShopInitializer>().currentMoney.ToString();
        //change master money
        GUN.PlayerMaster.Instance.Money -= CurrentItemPrice;
        //write car-changes to master
        GUN.PlayerMaster.Instance.MyCartItems = ShopManagerRef.GetComponent<ShopManager>().shopCartItems;

    }

}
