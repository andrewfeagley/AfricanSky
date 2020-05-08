using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : Pickup
{
    [SerializeField]
    int livesToAdd;
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        this.gameObject.SetActive(true);
    }

    public override void PickUp(int amountToRestore)
    {
        player.LivesIncreased(amountToRestore);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            this.gameObject.SetActive(false);
            PickUp(livesToAdd);
        }
    }

    private void OnEnable()
    {
        transform.SetParent(null);
        transform.localScale = Vector3.one;
    }
}
