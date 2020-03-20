using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Player player;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void DealDamage(int damageAmount)
    {

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
