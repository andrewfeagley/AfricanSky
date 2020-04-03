using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int health;

    public virtual void TakeDamage(int amount)
    {
        health -= amount;
    }
}
