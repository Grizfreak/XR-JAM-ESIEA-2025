using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OnStart : MonoBehaviour
{
    public GameObject buttonNext;
    public GameObject musicButton;
    // Start is called before the first frame update
    void Start()
    {
        buttonNext.GetComponent<XRSimpleInteractable>().selectEntered.AddListener(args => { GameManager.instance.LoadGame(args);});
        musicButton.GetComponent<XRSimpleInteractable>().selectEntered.AddListener(args => { SoundsManager.instance.changeSoundType(args);});
    }
}
