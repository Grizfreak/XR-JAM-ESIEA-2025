using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootProjectile : MonoBehaviour
{
    public AudioSource shootSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot(Transform startPoint, Vector3 direction, float velocity)
    {
        shootSound.Play();
        GameObject newProjectile = GetComponent<InventoryManager>().retrieveItem();
        newProjectile.SetActive(true);
        newProjectile.transform.position = startPoint.position;
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        rb.velocity = direction * velocity;
    }
}
