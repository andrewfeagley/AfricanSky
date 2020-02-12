using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class CameraController : MonoBehaviour
{
    //Speed in which the Camera follows
    public float cameraSpeed;
    //Boolean that checks whether the camera is currently following
    public bool isFollowing;

    //GameObject that the camera will follow
    private GameObject playerTarget;
    //Position that the Camera follows
    private  Vector3 playerXPos;
    void Awake()
    {
        //Searches for the object with the Player tag attached
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //Searches for the playerXPos position
        playerXPos = new Vector3(playerTarget.transform.position.x, 4.54f, -100f);
        //Checks if isFollowing is true and then proceeds to follow the playerXpos
        if (isFollowing == true) {
            transform.position = Vector3.Lerp(transform.position,playerXPos,cameraSpeed);
        
        }
        
    }
}
