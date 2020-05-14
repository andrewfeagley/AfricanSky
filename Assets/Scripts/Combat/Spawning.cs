using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemy;
    int randomSpawnPoint, randomEnemy;
    public static bool spawnAllowed;
    public Transform[] spawnPoints;
    [SerializeField] int maxEnemies;

    private void Start()
    {
        gameObject.SetActive(true);
        InvokeRepeating("SpawnEnemy", 0f, 5f);
    }
    private void Update()
    {
        if (CameraController.isFollowing == false)
        {
            spawnAllowed = true;
        }

        else if (CameraController.isFollowing == true)
        {
           // spawnAllowed = false;
            //GameManager.enemiesKilled = 0;
        }
    }
    void SpawnEnemy()
    {
        // if enemies on screen >= max enemies
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomEnemy = Random.Range(0, enemy.Length);
           GameObject enemyClone = Instantiate(enemy[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
            enemyClone.SetActive(true);
        }
    }
}
