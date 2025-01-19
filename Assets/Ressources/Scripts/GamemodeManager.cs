using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemodeManager : MonoBehaviour
{
    public GarbageManager garbageManager;
    public List<Canvas> garbageCanvas;
    public static GamemodeManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        switch (GameManager.instance.level)
        {
            case 0:
                Debug.Log("Start Level 1");
                setActiveGarbageCanvas(true);
                garbageManager.gameObject.SetActive(false);
                TimeManager.instance.StartTimer();
                break;

            case 1:
                Debug.Log("Start Level 2");
                setActiveGarbageCanvas(false);
                garbageManager.gameObject.SetActive(false);
                TimeManager.instance.StartTimer();
                break;

            case 2:
                Debug.Log("Start Level 3");
                setActiveGarbageCanvas(false);
                garbageManager.gameObject.SetActive(true);
                TimeManager.instance.StartTimer();
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void setActiveGarbageCanvas(bool boolean)
    {
        foreach (Canvas canvas in garbageCanvas)
        {
            canvas.gameObject.SetActive(boolean);
        }

    }

    public void EndGame()
    {
        garbageManager.gameObject.SetActive(false);
        InventoryManager.instance.gameObject.SetActive(false);
        ScoreManager.Instance.DisplayScore();
    }


}
