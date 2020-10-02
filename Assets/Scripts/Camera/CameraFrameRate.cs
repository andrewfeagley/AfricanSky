using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFrameRate : MonoBehaviour
{
    public int frameRate;
    // Start is called before the first frame update
    void Start()
    {
        if(frameRate == 0)
            Application.targetFrameRate = frameRate;
    }
}
