using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour, IDamageable
{
    /// <summary>
    /// id is the unique number that this HurtBox has
    /// </summary>
    public int id;

    private void Awake()
    {
        //This sets the id to a random number between 2 and 10
        this.id = UnityEngine.Random.Range(2, 10);
    }

    /// <summary>
    /// This function is called when the hurtbox collides with a hitbox, it reduces the health of the object the hurtbox belongs to by the value of the int amount
    /// </summary>
    /// <param name="amount">value to reduce health by when function is called, the amount belongs to the hitbox that collides with the hurtbox</param>
    private void Hit(int amount)
    {
        //reference to the current health of the parent object's IHaveHealth Health property
        int healthAmount = GetComponentInParent<IHaveHealth>().Health;
        //this runs to make sure Health doesn't fall into the negatives
        if(healthAmount <= 0 )
        {
            healthAmount = 0;
            this.gameObject.enabled = false;
            return;
        }
        //reduces parent object's health by the amount variable
        healthAmount -= amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Finds the hitbox that collides with this hurtbox, used to determine how much damage the hitbox deals to the hurtbox's parent
        HitBox attackerHitBox = collision.gameObject.GetComponent<HitBox>();
        int attackerHitBoxID = 0; //set to zero to prevent null ref error

        //check to make sure the colliding object actually has a HitBox script on it
        if (attackerHitBox != null)
            attackerHitBoxID = attackerHitBox.id;

        if (attackerHitBoxID != this.id)
        {
            Hit(attackerHitBox.amount);
            Debug.Log($"Hurtbox: " + id + " was hit for: " + attackerHitBox.amount + "damage.");
        }
    }
}
