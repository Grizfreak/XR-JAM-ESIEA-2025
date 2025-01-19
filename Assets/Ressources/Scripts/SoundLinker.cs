using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLinker : MonoBehaviour
{
    public SoundsManager.SoundEvent soundEvent;
    void Start()
    {
        AudioClip sound = SoundsManager.instance.GetSound(soundEvent);
        GetComponent<AudioSource>().clip = sound;
    }
}
