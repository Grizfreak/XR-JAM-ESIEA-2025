using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSlider : MonoBehaviour
{

    private void Update()
    {
        if (TimeManager.instance != null)
        {
            GetComponent<UnityEngine.UI.Slider>().value = TimeManager.instance.timeLeft / TimeManager.instance.timeTillFinish;
        }
    }
}
