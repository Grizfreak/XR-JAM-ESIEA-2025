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
    public GameObject windAnim;
    public AudioSource vacuumFullIn;
    public AudioSource vacuumIn;
    // Start is called before the first frame update
    void Start()
    {
        isSucking = false;
        suckionBox.SetActive(false);
        windAnim.SetActive(false);
        suckButton.action.performed += ctx => suckTrigger();
        suckReleaseButton.action.performed += ctx => suckReleaseTrigger();
    }

    // Update is called once per frame

    public void suckTrigger()
    {
        if (!GetComponent<projectTrajectory>().isProjecting && !GetComponent<InventoryManager>().IsFull())
        {
            vacuumIn.Play();
            vacuumIn.loop = true;
            isSucking = true;
            windAnim.SetActive(true);
            suckionBox.SetActive(true);
            suckionBox.GetComponent<suckTrigger>().setSuckForce(suckForce);
        }
        else
        {
            vacuumFullIn.Play();
            vacuumFullIn.loop = true;
        }
    }

    public void suckReleaseTrigger()
    {
        vacuumIn.Stop();
        vacuumIn.loop = false;
        vacuumFullIn.Stop();
        vacuumFullIn.loop = false;
        isSucking = false;
        windAnim.SetActive(false);
        // deactivate the suction box
        suckionBox.SetActive(false);
    }

    public void disableVacuum()
    {
        isSucking = false;
        windAnim.SetActive(false);
        // deactivate the suction box
        suckionBox.SetActive(false);
        vacuumIn.Stop();
        vacuumIn.loop = false;
        vacuumFullIn.Stop();
        vacuumFullIn.loop = false;
    }
}
