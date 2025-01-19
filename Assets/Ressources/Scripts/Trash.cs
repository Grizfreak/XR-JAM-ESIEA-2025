using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WSWhitehouse.TagSelector;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class Trash : MonoBehaviour
{
    public enum TrashType
    {
        Waste,
        Recyclable,
        Organic,
        Glass
    }

    [TagSelector] public string tagToSuck;
    public TrashType trashType;
    public Sprite icon;
    public GameObject particles;
    public bool hasBeenThrown = false;

    // Référence pour l'instance du système de particules
    private ParticleSystem.VelocityOverLifetimeModule velocityModule;

    public void Start()
    {
        gameObject.tag = tagToSuck;
    }

    public void throwAnim()
    {
        hasBeenThrown = true;
        // instancier un système de particules
        GameObject particle = Instantiate(particles, transform.position, particles.transform.rotation);
        particle.GetComponent<ParticleSystem>().Play();
        Destroy(particle, 2f);

    }
}
