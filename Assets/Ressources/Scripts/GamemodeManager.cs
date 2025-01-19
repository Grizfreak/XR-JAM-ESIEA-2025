using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemodeManager : MonoBehaviour
{
    public GarbageManager garbageManager;
    public List<Canvas> garbageCanvas;
    public static GamemodeManager instance;
    public GameObject leftController;
    public GameObject rightController;
    public GameObject pokeInteractorLeft;
    public GameObject pokeInteractorRight;
    public GameObject XRModelLeft;
    public GameObject XRModelRight;

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
        if (GameManager.instance.isRightHanded)
        {
            leftController.SetActive(false);
            XRModelLeft.SetActive(false);
            XRModelRight.SetActive(false);
            pokeInteractorRight.SetActive(false);
            pokeInteractorLeft.SetActive(false);
            rightController.SetActive(true);
        } else
        {
            rightController.SetActive(false);
            XRModelLeft.SetActive(false);
            XRModelRight.SetActive(false);
            pokeInteractorRight.SetActive(false);
            pokeInteractorLeft.SetActive(false);
            leftController.SetActive(true);
        }
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
        GameObject gun = GameObject.FindGameObjectWithTag("Gun");
        gun.SetActive(false);
        if (GameManager.instance.isRightHanded)
        {
            XRModelRight.SetActive(true);
            pokeInteractorRight.SetActive(true);
        }
        else
        {
            XRModelLeft.SetActive(true);
            pokeInteractorLeft.SetActive(true);
        }
        garbageManager.gameObject.SetActive(false);
        InventoryManager.instance.DeleteObject();
        ScoreManager.Instance.DisplayScore();
    }


}
