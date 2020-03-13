using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    private Vector3 screenBounds;
    public float yMin, yMax;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, Camera.main.transform.position.x - 7.5f, Camera.main.transform.position.x + 7.5f);
        viewPos.y = Mathf.Clamp(viewPos.y, yMin, yMax);
        transform.position = viewPos;
    }
}
