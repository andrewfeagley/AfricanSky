using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour, IDamageable
{
    public event Action HurtBoxWasHit;
    public int id;
    public LayerMask layerMask;

    private void Awake()
    {
        this.id = UnityEngine.Random.Range(2, 10);
        
    }

    public void Hit(int amount)
    {
        int healthAmount = GetComponentInParent<IHaveHealth>().Health;
        if(healthAmount <= 0 )
        {
            return;
        }

        healthAmount -= amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitBox attackerHitBox = collision.gameObject.GetComponent<HitBox>();
        int attackerHitBoxID = 0;

        if (attackerHitBox != null)
            attackerHitBoxID = attackerHitBox.id;

        if (attackerHitBoxID != this.id)
        {
            Hit(attackerHitBox.amount);
            Debug.Log($"Hurtbox: " + id + " was hit for: " + attackerHitBox.amount + "damage.");
        }
    }
}
