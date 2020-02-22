using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatComponent 
{
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
}
