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
    public float redEnd;
    public float greenEnd;

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
        replayButton.GetComponent<XRSimpleInteractable>().selectEntered.AddListener(args => { GameManager.instance.resetLevel(args); });
        nextButton.GetComponent<XRSimpleInteractable>().selectEntered.AddListener(args => { GameManager.instance.LoadNextLevel(args); });
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
        slider.maxValue = greenEnd;
        slider.minValue = redEnd;
        float value = score;

        if (score <= redEnd)
        {
            value = redEnd;
        }
        else if (score >= greenEnd)
        {
            value = greenEnd;
        }
        slider.value = value;
        slider.GetComponent<FaceDisplayer>().onValueChanged(value,redEnd,greenEnd);

        if (score <= -30)
        {
            // disable the next button
            nextButton.GetComponent<XRSimpleInteractable>().enabled = false;
            nextAble.SetActive(false);
            nextNotAble.SetActive(true);
        }
    }

}
