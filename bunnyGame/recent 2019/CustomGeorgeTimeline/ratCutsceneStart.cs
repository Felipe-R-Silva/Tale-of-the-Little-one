using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ratCutsceneStart : MonoBehaviour
{
    public Animator[] ListAnimations;
    public GameObject DirectorGameObject;
    float prevSpeed;

    public void PlayTimeLine()
    {
        PlayableDirector a= DirectorGameObject.GetComponent<PlayableDirector>();
        if (a != null)
        {
            foreach (var item in ListAnimations)
            {
                item.speed = prevSpeed;
            }
            a.Play();
        }
    }
    public void PauseTimeLine()
    {
        PlayableDirector a = DirectorGameObject.GetComponent<PlayableDirector>();
        if (a != null)
        {
            foreach (var item in ListAnimations)
            {
                prevSpeed = item.speed;
                item.speed = 0;
            }
            StartCoroutine(WaitAndPrint());
            a.Pause();
        }
    }
    private IEnumerator WaitAndPrint()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (Input.GetKey("space"))
            {
                PlayTimeLine();
                break;
            }
        }
    }

}
