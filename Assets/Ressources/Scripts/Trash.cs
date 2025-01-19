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
    public ParticleSystem badAnim;

    // Référence pour l'instance du système de particules
    private ParticleSystem.VelocityOverLifetimeModule velocityModule;

    public void Start()
    {
        badAnim = GetComponentInChildren<ParticleSystem>();
        velocityModule = badAnim.velocityOverLifetime; // Accéder au module de vitesse des particules
        gameObject.tag = tagToSuck;
    }

    public void throwAnim()
    {
        // Lancer l'animation des particules
        badAnim.Play();

        // Diriger constamment les particules vers la verticale
        // En modifiant la vitesse des particules en fonction de la verticale (axe Y)
        velocityModule.x = 0;  // Pas de mouvement horizontal
        velocityModule.y = 1;  // Mouvement constant vers le haut (vertical)
        velocityModule.z = 0;  // Pas de mouvement sur l'axe Z
    }
}
