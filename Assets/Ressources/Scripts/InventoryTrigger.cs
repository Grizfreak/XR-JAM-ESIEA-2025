using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WSWhitehouse.TagSelector;

public class InventoryTrigger : MonoBehaviour
{
    public GameObject suckManager;
    [TagSelector] public string tagToSuck;


    private void Start()
    {
        // the script is in the parent object
        suckManager = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        // if the object is a suckable and the player is sucking
        if (other.gameObject.CompareTag(tagToSuck) && suckManager.GetComponent<suckProjectile>().isSucking && !suckManager.GetComponent<InventoryManager>().IsFull())
        {
            Debug.Log("Suck");
            // suck the object
            suckManager.GetComponent<InventoryManager>().AddItem(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
