using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WSWhitehouse.TagSelector;

[RequireComponent(typeof(Collider))]
public class TrashCollector : MonoBehaviour
{
    public Trash.TrashType TrashType;
    [TagSelector] public string tagToSuck;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToSuck))
        {
            Destroy(other.gameObject);
        }
    }
}
