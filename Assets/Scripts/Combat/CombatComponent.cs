using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatComponent 
{
    private float health = 100;

    public CombatComponent()
    {

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
