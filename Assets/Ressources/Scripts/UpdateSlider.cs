using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSlider : MonoBehaviour
{

    private void Update()
    {
        if (TimeManager.instance != null)
        {
            // value should be 1 when time is up
            // value should be 0 when time is at the beginning
            float value = 1f - (TimeManager.instance.timeLeft / TimeManager.instance.timeTillFinish);
            GetComponent<UnityEngine.UI.Slider>().value = value;
        }
    }
}
