using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, Camera.main.transform.position.x - 4f,50f);
        transform.position = viewPos;
    }
}
