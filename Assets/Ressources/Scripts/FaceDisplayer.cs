using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceDisplayer : MonoBehaviour
{
    public Image faceImage;
    public Sprite[] faces;
    
    public void onValueChanged(float value, float minValue, float maxValue)
    {
        // values goes from minValue to maxValue
        // minValue can be negative
        // if value is under 25%, display the first face
        if (value < minValue + 0.25 * (maxValue - minValue))
        {
            faceImage.sprite = faces[0];
        }
        // if value is under 0.75, display the second face
        else if (value < minValue + 0.75 * (maxValue - minValue))
        {
            faceImage.sprite = faces[1];
        }
        // if value is under 1, display the third face
        else
        {
            faceImage.sprite = faces[2];
        }
    }
}
