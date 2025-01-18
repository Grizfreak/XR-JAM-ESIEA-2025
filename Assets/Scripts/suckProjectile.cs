using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class suckProjectile : MonoBehaviour
{
    public InputActionReference suckButton;
    public InputActionReference suckReleaseButton;
    public float suckForce;
    public bool isSucking;
    public GameObject suckionBox;
    // Start is called before the first frame update
    void Start()
    {
        isSucking = false;
        suckionBox.SetActive(false);
        suckButton.action.performed += ctx => suckTrigger();
        suckReleaseButton.action.performed += ctx => suckReleaseTrigger();
    }

    // Update is called once per frame

    public void suckTrigger()
    {
        if (!GetComponent<projectTrajectory>().isProjecting)
        {
            isSucking = true;
            suckionBox.SetActive(true);
            suckionBox.GetComponent<suckTrigger>().setSuckForce(suckForce);
        }
    }

    public void suckReleaseTrigger()
    {
        isSucking = false;
        // deactivate the suction box
        suckionBox.SetActive(false);
    }
}
