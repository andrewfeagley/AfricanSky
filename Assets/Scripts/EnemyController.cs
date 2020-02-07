using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool inSight;
    public GameObject player;
    private Rigidbody2D rigidBody;
    private float movementSpeed;
    public float walkMoveSpeed = 2;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        movementSpeed = walkMoveSpeed;
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player) {
            inSight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player) {
            inSight = false;
        }
    }
}
