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

    public void Start()
    {
        badAnim = GetComponentInChildren<ParticleSystem>();
        gameObject.tag = tagToSuck;
    }

    public void throwAnim()
    {
        badAnim.Play();
    }
}
