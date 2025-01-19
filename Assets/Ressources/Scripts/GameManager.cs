using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int level;
    public bool isRightHanded;

    private void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel(SelectEnterEventArgs args)
    {
        args.interactableObject.transform.gameObject.GetComponentInChildren<AudioSource>().Play();
        level++;
        if (level > 2)
        {
            StartCoroutine(WaitForSound(args, "LobbyScene"));
            return;
        }
        StartCoroutine(WaitForSound(args, "GameScene"));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void resetLevel(SelectEnterEventArgs args)
    {
        args.interactableObject.transform.gameObject.GetComponentInChildren<AudioSource>().Play();
        StartCoroutine(WaitForSound(args, "GameScene"));
    }

    public void LoadGame(SelectEnterEventArgs args)
    {
        args.interactableObject.transform.gameObject.GetComponentInChildren<AudioSource>().Play();
        level = 0;
        if (args.interactorObject.transform.parent.gameObject.name.Contains("Right"))
        {
            isRightHanded = true;
        }
        else isRightHanded = false;
        // wait for sound to finish
        StartCoroutine(WaitForSound(args, "GameScene"));
    }

    private IEnumerator WaitForSound(SelectEnterEventArgs args, string scene)
    {
        yield return new WaitForSeconds(args.interactableObject.transform.gameObject.GetComponentInChildren<AudioSource>().clip.length);
        LoadScene(scene);
    }
}
