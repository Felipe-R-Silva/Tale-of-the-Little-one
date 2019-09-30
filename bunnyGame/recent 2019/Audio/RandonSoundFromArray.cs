using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonSoundFromArray : MonoBehaviour {

    public AudioClip[] audioArray;
    public bool randomPich;
    public bool parentToScriptObject;
    public bool destroyRootOnAudioEnd;

    public void randomAudioArray ()
        {
        int audio = Random.Range(0, audioArray.Length);//picks random audio form array
        GameObject AudioInstance=SpawnrandomAudioArray(audioArray[audio]);//create a object that plays the sound
        PlayAudio( AudioInstance);
    }
    public void playAllAudiosArray()
    {
        int audio = Random.Range(0, audioArray.Length);//picks random audio form array
        foreach (AudioClip audioChoice in audioArray)
        {
            GameObject AudioInstance = SpawnrandomAudioArray(audioChoice);//create a object that plays the sound
            PlayAudio(AudioInstance);
        }
    }
    public GameObject SpawnrandomAudioArray(AudioClip audio)
    {
        GameObject newaudiosorce = new GameObject();//create new GameObject
        newaudiosorce.name = "AudioInstance";//nameGame object
        if (parentToScriptObject) { newaudiosorce.transform.parent = this.transform; }//Parent to the this object
        newaudiosorce.AddComponent<AudioSource>();//create audio source
        newaudiosorce.GetComponent<AudioSource>().playOnAwake = false;//make sure it will not autoplay
        if (randomPich) { newaudiosorce = SetrandomPitch(newaudiosorce); }//random Pich
        newaudiosorce.GetComponent<AudioSource>().clip = audio;//add the desired audio
        return newaudiosorce;

    }
    public GameObject SetrandomPitch(GameObject audiosorce)
    {
        float pitch = Random.Range(0.7f, 1.5f);
        audiosorce.GetComponent<AudioSource>().pitch = pitch;
        return audiosorce;
    }
    public void PlayAudio(GameObject AudioInstance)
    {
        AudioInstance.GetComponent<AudioSource>().Play();//play the desired audio
        AudioInstance.AddComponent<SelfDestructAudio>();
       // Destroy(this.transform.parent.gameObject);
    }
}
