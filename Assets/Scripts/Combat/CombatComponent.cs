using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatComponent : MonoBehaviour
{
    [SerializeField] Text healthText;

    private float health = 100;

    public void DamagedBy(float damage)
    {
        health -= damage;
        UpdateText();
    }

    public void HealedBy(float heal)
    {
        health += heal;
        UpdateText();
    }

    public void UpdateText()
    {
        //Debug.Log($"{this.gameObject.name} health: {health}");
        healthText.text = $"{this.gameObject.name} Health: {health}";  //{this.gameObject.name}
    }

    private void Update()
    {
        CheckForDeath();
    }

    void CheckForDeath()
    {
        if(health <= 0)
        {
            Debug.Log($"{this.gameObject.name} death");
            Destroy(gameObject);
        }
    }

}
