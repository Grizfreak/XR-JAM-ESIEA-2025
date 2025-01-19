using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance;
    public enum SoundType
    {
        Standard,
        Goofy,
        Vocal
    }

    public enum SoundEvent
    {
        VacuumIn,
        VacuumOut,
        VacuumFullIn,
        VacuumEmptyOut,
        ButtonPress,
        Conveyor,
        GoodTrash,
        MiddleTrash,
        BadTrash,
        EndLevel
    }

    public AudioClip[] standardSounds;
    public AudioClip[] goofySounds;
    public AudioClip[] vocalSounds;

    public SoundType currentSoundType;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public AudioClip GetSound(SoundEvent soundEvent)
    {
        switch (currentSoundType)
        {
            case SoundType.Standard:
                return standardSounds[(int)soundEvent];
            case SoundType.Goofy:
                return goofySounds[(int)soundEvent];
            case SoundType.Vocal:
                return vocalSounds[(int)soundEvent];
            default:
                return standardSounds[(int)soundEvent];
        }
    }

    public void changeSoundType(SelectEnterEventArgs args)
    {
        int numberOfTypes = System.Enum.GetNames(typeof(SoundType)).Length;
        currentSoundType = (SoundType)(((int)currentSoundType + 1) % numberOfTypes);
        args.interactableObject.transform.gameObject.GetComponentInChildren<AudioSource>().clip = GetSound(SoundEvent.ButtonPress);
        args.interactableObject.transform.gameObject.GetComponentInChildren<AudioSource>().Play();
        GameObject.FindGameObjectWithTag("NextButtonLobby").GetComponentInChildren<AudioSource>().clip = GetSound(SoundEvent.ButtonPress);
    }
}
