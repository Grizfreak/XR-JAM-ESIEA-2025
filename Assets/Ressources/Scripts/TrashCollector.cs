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
    private int goodBinScore = 15;
    private int wrongBinScore = -5;

    private void Start()
    {
        if(ScoreManager.Instance != null)
        {
            goodBinScore = ScoreManager.Instance.rightBinScoreValue;
            wrongBinScore = ScoreManager.Instance.wrongBinScoreValue;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToSuck))
        {
            if (other.GetComponent<Trash>().trashType == TrashType)
            {
                goodAnim.Play();
                goodAnim.GetComponent<AudioSource>().Play();
                ScoreManager.Instance.AddScore(goodBinScore);
            }
            else
            {
                badAnim.Play();
                badAnim.GetComponent<AudioSource>().Play();
                ScoreManager.Instance.AddScore(wrongBinScore);
            }
            Destroy(other.gameObject);
        }
    }
}
