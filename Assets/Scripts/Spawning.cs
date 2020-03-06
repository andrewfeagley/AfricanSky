using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] enemy;
    int randomSpawnPoint, randomEnemy;
    public static bool spawnAllowed;
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 5f, 5f);
    }

    private void FixedUpdate()
    {
        if (CameraController.isFollowing == false)
        {
            spawnAllowed = true;
        }
        else if (CameraController.isFollowing == true)
        {
            spawnAllowed = false;
            GameManager.enemiesKilled = 0;
        }
        Debug.Log(CameraController.isFollowing);
        Debug.Log(GameManager.enemiesKilled);
    }

    void SpawnEnemy()
    {

        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomEnemy = Random.Range(0, enemy.Length);
            Instantiate(enemy[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
