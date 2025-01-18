using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suckTrigger : MonoBehaviour
{
    private float suckForce;
    private GameObject suckManager;
    // Start is called before the first frame update
    private void Start()
    {
        suckManager = transform.parent.gameObject;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Suckable") && !suckManager.GetComponent<InventoryManager>().IsFull())
        {
            // attract the object to the player
            Vector3 direction = transform.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * suckForce);
        }
        else if (other.CompareTag("Suckable") && suckManager.GetComponent<InventoryManager>().IsFull())
        {
            Debug.Log("Inventory is full");
            //TODO song
        }
    }

    public void setSuckForce(float force)
    {
        suckForce = force;
    }
}
