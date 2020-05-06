using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public GameObject player;
    bool inSight = false;

    [SerializeField] GameObject enemy;
    private Enemy enemyScript;

    private void Start()
    {
        enemy.GetComponent<Enemy>();
        enemyScript.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            inSight = true;
            enemyScript.enabled = true;
            Destroy(gameObject);
        }
    }
}
