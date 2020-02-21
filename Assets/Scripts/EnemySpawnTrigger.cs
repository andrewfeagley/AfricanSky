using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject enemyInstantiation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spawn Trigger") {
            Instantiate(enemyInstantiation, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
