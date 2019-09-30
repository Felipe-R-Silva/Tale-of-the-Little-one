using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillRat : MonoBehaviour
{
    public GameObject Rat;

    public void KillRAt() {
        Rat.SetActive(false);
    }
}
