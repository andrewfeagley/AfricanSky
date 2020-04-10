using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField]
    int healthToRestore;
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        this.gameObject.SetActive(true);
    }

    public override void PickUp(int amountToRestore)
    {
        player.Health += amountToRestore;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() && player.Health < player.maxHealth)
        {
            this.gameObject.SetActive(false);
            PickUp(healthToRestore);
        }
    }
}
