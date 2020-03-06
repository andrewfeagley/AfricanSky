using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static int enemiesKilled;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesKilled == 6 && CameraController.isFollowing == false) {
            CameraController.isFollowing = true;

        }
    }
}
