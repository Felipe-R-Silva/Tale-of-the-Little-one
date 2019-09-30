using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalCount : MonoBehaviour
{
    static int MaxNumber;
    public int currentNumber;
    public GameObject crystalCounter;
    public Text UI_Text;

    private void Start()
    {
        MaxNumber = transform.childCount;
        UI_Text.text = "0" + "/" + MaxNumber;
    }
    public void Add1Crystal(Text UI_Text)
    {
        print(currentNumber);
        UI_Text.text = ""+ (currentNumber + 1)+"/"+ CrystalCount.MaxNumber;
        crystalCounter.GetComponent<CrystalCount>().currentNumber = currentNumber+1;
    }
}
