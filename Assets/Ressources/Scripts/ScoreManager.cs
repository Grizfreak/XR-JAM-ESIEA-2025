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
        //  > -30 orange  / > +10 green start
        //  -60 red / +30 green end
        float value = 0f;
        if (score < -60)
        {
            value = 0f;
        }
        else if (score < -30)
        {
            value = (score + 60) / 30f * 0.5f;
        }
        else if (score < 10)
        {
            value = 0.5f + score / 40f * 0.5f;
        }
        else if (score < 30)
        {
            value = 1f;
        }
        else
        {
            value = 1f + (score - 30) / 30f * 0.5f;
        }

        slider.value = value;
        slider.GetComponent<FaceDisplayer>().onValueChanged(value);

        if (score < -30)
        {
            // disable the next button
            nextButton.GetComponent<XRSimpleInteractable>().enabled = false;
            nextAble.SetActive(false);
            nextNotAble.SetActive(true);
        }
    }

}
