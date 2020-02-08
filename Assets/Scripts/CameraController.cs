using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;
    public bool isFollowing;
    private GameObject playerTarget;
    private  Vector3 playerXPos;
    void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        playerXPos = new Vector3(playerTarget.transform.position.x, 4.54f, -100f);
        if (isFollowing == true) {
            transform.position = Vector3.Lerp(transform.position,playerXPos,cameraSpeed);
        
        }
        
    }
}
