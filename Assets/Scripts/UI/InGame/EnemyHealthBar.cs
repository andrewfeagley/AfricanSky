using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;
    Image imageFill;
    float enemyStartingHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (enemy == null)
            enemy = FindObjectOfType<Enemy>();
        
        enemy.OnHealthChanged += Enemy_OnHealthChanged;

        if (imageFill == null)
            imageFill = GetComponent<Image>();

        enemyStartingHealth = enemy.Health;
        imageFill.fillAmount = enemyStartingHealth;
    }

    private void Enemy_OnHealthChanged(object sender, System.EventArgs e)
    {
        imageFill.fillAmount = enemy.Health / (enemyStartingHealth);
    }
}
