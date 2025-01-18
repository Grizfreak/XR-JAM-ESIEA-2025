using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WSWhitehouse.TagSelector;

public class TrashDestroyer : MonoBehaviour
{
    [TagSelector] public string tagToDestroy;
    public bool shouldRemoveScore;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagToDestroy))
        {
            Destroy(collision.gameObject);
            if (shouldRemoveScore)
            {
                ScoreManager.Instance.AddScore(-10);
            }
        }
    }
}
