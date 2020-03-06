using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStop : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject otherObject;
    public GameObject[] enemy;
    int randomSpawnPoint, randomEnemy;
    public static bool spawnAllowed;
    
    private void Start()
    {

        
        otherObject = GameObject.Find("Camera Mid");
        InvokeRepeating("SpawnEnemy",0f,2f);
    }


    private void Update()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks to see if the otherObject has the specified tag and if so, deactivitates the object and turns isFollowing false.
        if (otherObject.tag == "CameraMidPoint")
        { 
            otherObject = otherObject.transform.parent.gameObject;
            CameraController.isFollowing = false;
            gameObject.SetActive(false);
        }
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
