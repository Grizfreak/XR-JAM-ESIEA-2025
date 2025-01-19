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

    public void LoadNextLevel()
    {
        level++;
        if (level > 2)
        {
            LoadMenu();
            return;
        }
        LoadScene("GameScene");
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

    public void resetLevel()
    {
        LoadScene("GameScene");
    }

    public void LoadMenu()
    {
        LoadScene("LobbyScene");
    }

    public void LoadGame(SelectEnterEventArgs args)
    {
        level = 0;
        if (args.interactorObject.transform.parent.gameObject.name.Contains("Right"))
        {
            isRightHanded = true;
        }
        else isRightHanded = false;
        LoadScene("GameScene");
    }
}
