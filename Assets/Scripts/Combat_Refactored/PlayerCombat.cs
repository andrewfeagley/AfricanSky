using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Player player;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange;

    public event EventHandler<CombatEvents> OnHealthChanged;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void DealDamage(int damageAmount)
    {

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

public class CombatEvents : EventArgs
{
    public float MaxHealth { get; set; }
    public float Health { get; set; }
}
