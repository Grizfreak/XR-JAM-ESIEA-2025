using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceDisplayer : MonoBehaviour
{
    public Image faceImage;
    public Sprite[] faces;
    
    public void onValueChanged(float value)
    {
        // if value is under 0.25, display the first face
        if (value < 0.25)
        {
            faceImage.sprite = faces[0];
        }
        // if value is under 0.75, display the second face
        else if (value < 0.75)
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
