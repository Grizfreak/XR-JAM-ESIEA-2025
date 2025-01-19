using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WSWhitehouse.TagSelector;

[RequireComponent(typeof(Collider))]
public class TrashCollector : MonoBehaviour
{
    public Trash.TrashType TrashType;
    [TagSelector] public string tagToSuck;
    public ParticleSystem badAnim;
    public ParticleSystem goodAnim;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToSuck))
        {
            if (other.GetComponent<Trash>().trashType == TrashType)
            {
                goodAnim.Play();
                ScoreManager.Instance.AddScore(10);
            }
            else
            {
                badAnim.Play();
                ScoreManager.Instance.AddScore(-5);
            }
            Destroy(other.gameObject);
        }
    }
}
