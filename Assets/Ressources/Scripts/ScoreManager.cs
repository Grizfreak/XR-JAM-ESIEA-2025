using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public static ScoreManager Instance;
    public GameObject scoreScene;
    public GameObject nextButton;
    public GameObject replayButton;
    public GameObject nextAble;
    public GameObject nextNotAble;
    public float redStart = -30f;
    public float redEnd = -60f;
    public float greenStart = 20f;
    public float greenEnd = 50f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Start()
    {
        nextButton.GetComponent<XRSimpleInteractable>().enabled = true;
        nextAble.SetActive(true);
        nextNotAble.SetActive(false);
        replayButton.GetComponent<XRSimpleInteractable>().selectEntered.AddListener(delegate { GameManager.instance.resetLevel(); });
        nextButton.GetComponent<XRSimpleInteractable>().selectEntered.AddListener(delegate { GameManager.instance.LoadNextLevel(); });
        score = 0;
        scoreScene.SetActive(false);
    }

    public void AddScore(int score)
    {
        this.score += score;
    }

    public void DisplayScore()
    {
        scoreScene.SetActive(true);
        // get the slider component in the children of the scoreScene
        UnityEngine.UI.Slider slider = scoreScene.GetComponentInChildren<UnityEngine.UI.Slider>();
        slider.transform.parent.gameObject.GetComponentInChildren<AudioSource>().Play();
        float value = 0f;

        if (score >= greenEnd)
        {
            value = 1f;
        } else if ( score <= redEnd)
        {
            value = 0f;
        }
        else
        {
            value = (score - (-1 * redEnd)) / (greenEnd - (-1 * redEnd));
        }
        slider.value = value;
        slider.GetComponent<FaceDisplayer>().onValueChanged(value);

        if (score <= -30)
        {
            // disable the next button
            nextButton.GetComponent<XRSimpleInteractable>().enabled = false;
            nextAble.SetActive(false);
            nextNotAble.SetActive(true);
        }
    }

}
