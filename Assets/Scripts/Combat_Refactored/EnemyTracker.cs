using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTracker : MonoBehaviour
{
    Dictionary<object, Enemy> enemiesDictionary = new Dictionary<object, Enemy>();
    static int numberofEnemiesKilled;
    Spawning spawning;
    

    private void Start()
    {
        spawning = FindObjectOfType<Spawning>();
        spawning.OnEnemySpawned += Spawning_OnEnemySpawned;
        enemiesDictionary.Add(new object(), FindObjectOfType<Enemy>());
        //enemiesDictionary[0].OnDeath += EnemyTracker_OnDeath;
    }

    private void Spawning_OnEnemySpawned(object sender, System.EventArgs e)
    {
        if(!enemiesDictionary.ContainsKey(sender))
        {
            enemiesDictionary.Add(sender, spawning.enemySpawned);
            enemiesDictionary[sender].GetComponent<Enemy>().OnDeath += EnemyTracker_OnDeath;
        }
    }

    private void EnemyTracker_OnDeath(object sender, System.EventArgs e)
    {
        if(enemiesDictionary.ContainsKey(sender))
        {
            numberofEnemiesKilled++;
            Debug.Log($"The number of enemies killed so far is: {numberofEnemiesKilled}");
            Enemy enemyToUnsubFrom = enemiesDictionary[sender].GetComponent<Enemy>();
            enemyToUnsubFrom.OnDeath -= EnemyTracker_OnDeath;

            enemiesDictionary.Remove(sender);
        }
    }
}
