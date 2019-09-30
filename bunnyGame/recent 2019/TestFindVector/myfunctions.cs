using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class myfunctions : MonoBehaviour
{
    public void DestroyIn3Seconds(GameObject target)
     {
        Destroy(target, 3);
    }
    public void DestroyInstant(GameObject target)
    {
        Destroy(target);
    }
    
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void AddMoney(GameObject NumberToAdd)
    {
        GUN.PlayerMaster.Instance.Money += NumberToAdd.GetComponent<CrystalCount>().currentNumber;
    }
    public void SetMoneyFromShop(GameObject NumberToAdd)
    {
        GUN.PlayerMaster.Instance.Money = NumberToAdd.GetComponent<ShopInitializer>().currentMoney;
    }
    public void MakeMouseVisible()
    {
        //hide mouse first time
        Cursor.visible = true;//hide mouse
        Cursor.lockState = CursorLockMode.None;//lock mouse
    }
    public void MakeMouseInvisible()
    {
        //hide mouse first time
        Cursor.visible = false;//hide mouse
        Cursor.lockState = CursorLockMode.Locked;//lock mouse
    }
    public void MoveUp(GameObject target)
    {
        target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 5, target.transform.position.z);
    }
    public void MoveDown10(GameObject target)
    {
        target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y -10, target.transform.position.z);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
