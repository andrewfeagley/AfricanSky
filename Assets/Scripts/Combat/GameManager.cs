using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;
using System;
using Object = UnityEngine.Object;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static int score;
    
    public static int enemiesKilled = 0;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (enemiesKilled == 6 && CameraController.isFollowing == false) {
            CameraController.isFollowing = true;
            Tutorial.gosign.SetActive(true);
        }

        if (PlayerController.lives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
