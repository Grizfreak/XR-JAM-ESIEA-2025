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

    public void Start()
    {
        gameObject.tag = tagToSuck;
    }
}
