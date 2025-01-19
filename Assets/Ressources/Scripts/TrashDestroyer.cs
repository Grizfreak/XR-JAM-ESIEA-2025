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
            if (shouldRemoveScore)
            {
                // the animation should play in up direction so we need to rotate it
                collision.gameObject.GetComponent<Trash>().badAnim.transform.rotation.SetLookRotation(Vector3.up);
                collision.gameObject.GetComponent<Trash>().throwAnim();
                Destroy(collision.gameObject, 2f);
                ScoreManager.Instance.AddScore(-10);
            }
            else Destroy(collision.gameObject);
        }
    }
}
