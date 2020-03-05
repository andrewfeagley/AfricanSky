using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatComponent : MonoBehaviour
{
    [SerializeField] Text healthText;

    public float health = 100;
    public float[] attackDamage = new float[3]; //punch, kick, super

    public CombatComponent(float helath, float a1, float a2, float a3)
    {
        this.health = helath;
        attackDamage[0] = a1;
        attackDamage[1] = a2;
        attackDamage[2] = a3;
    }

    public void DamagedBy(float damage)
    {
        health -= damage;
    }

    public void HealedBy(float heal)
    {
        health += heal;
    }

    private void Update()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        if (gameObject.CompareTag("Player"))
        {
            healthText.text = $"Player Health:{health}";
        }
        else if(gameObject.CompareTag("Enemy"))
        {
            healthText.text = $"Enemy Health:{health}";
        }     
    }

}
