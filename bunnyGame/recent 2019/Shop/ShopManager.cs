using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int price;
    delegate void MyDelegate(int Price);
    MyDelegate FunctionBuy;
    public CarStatus shopCartItems;
    public Text PriceBox;

    public int BuyWoodEngine
    {
        get { return price; }
        set
        {
            //selected in the inspector
            price = value;
            //Some other code(calls the function that purchass teh engine )
            FunctionBuy = null;
            FunctionBuy = WoodEngine;
            FunctionBuy(price);
        }
    }
    

    public void WoodEngine(int num)
    {
        price = num;
        //Player.GetComponent<MoveControll>().maxSpeed = 5;
        print("purchased Wood Engine Price: " + num);
    }
    /*
    public void NuclearEngine(int num)
    {
        price = num;
        //Player.GetComponent<MoveControll>().maxSpeed = 20;
        /print("purchased Nuclear Engine Price: " + num);
    }
    */
}
