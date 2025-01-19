using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timeTillFinish = 45f;
    public float timeLeft = 0f;
    public static TimeManager instance;

    private void Awake()
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

    public void StartTimer()
    {
        StartCoroutine(Countdown());
        SpawningBehavior.instance.canSpawn = true;
    }

    private IEnumerator Countdown()
    {
        timeLeft = timeTillFinish;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return null;
        }
        SpawningBehavior.instance.canSpawn = false;
        GamemodeManager.instance.EndGame();
    }
}
