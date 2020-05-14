using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public static GameObject gosign;

    private void Start()
    {
        gosign = GameObject.FindGameObjectWithTag("GO");
        gosign.SetActive(false);
    }
    private void Update()
    {
        if (GameManager.Score == 1 && CameraController.isFollowing == false)
        {
            CameraController.isFollowing = true;
            gosign.SetActive(true);
            GameManager.Score = 0;
        }
    }
}
