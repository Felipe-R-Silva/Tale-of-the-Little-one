using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(CheckIfmusicStoped((bool callback) => {
            Destroy(this.gameObject);
        }, this.gameObject));

    }
    IEnumerator CheckIfmusicStoped(System.Action<bool> callBack, GameObject newaudiosorce)
    {

        while (newaudiosorce.GetComponent<AudioSource>().isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
        }
        callBack(true);
            //Destroy(newaudiosorce); -- heavy error
    }

}
