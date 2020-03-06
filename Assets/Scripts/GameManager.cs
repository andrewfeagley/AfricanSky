using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static int enemiesKilled;
    public static int totalEnemiesKilled;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemiesKilled == 6 && CameraController.isFollowing == false) {
            CameraController.isFollowing = true;

        }

        if (totalEnemiesKilled >= 18) {
            SceneManager.LoadScene("WinScene");
        }

        if (PlayerController.lives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
