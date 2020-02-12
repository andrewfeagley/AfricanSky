using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //used to check whether the Enemy is in sight of enemy
    public bool inSight;

    public GameObject player;
    private Rigidbody2D rigidBody;

    //Speed in which the Enemy moves.
    private float movementSpeed;
    public float walkMoveSpeed = 2;

    //Position in which the Enemy is facing.
    private bool facingRight;
    private bool facingLeft;

    //Max X and Y movement constraints for Enemy
    public float xMin, xMax, yMin, yMax;

    void Awake()
    {
        //Searches for the object with the Player tag
        player = GameObject.FindGameObjectWithTag("Player");

        rigidBody = GetComponent<Rigidbody2D>();
        movementSpeed = walkMoveSpeed;
    }

    void FixedUpdate()
    {
        //Finds and follows the players position while keeping the Enemy in X and Y constraints
        Vector2 direction = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        rigidBody.position = new Vector2(Mathf.Clamp(rigidBody.position.x, xMin, xMax), Mathf.Clamp(rigidBody.position.y, yMin, yMax));

        // Flips the direction the Enemy is looking
        if (transform.position.x < player.transform.position.x && !facingRight)
        {
            Flip();
        }
        else if (transform.position.x > player.transform.position.x && facingRight)
        {
            Flip();
        }

    }

    // Activates as the Enemy enters the inSight trigger
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player) {
            inSight = true;
        }
    }

    // deactivates as the Enemy enters the inSight trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player) {
            inSight = false;
        }
    }

    //Allows for the Enemy to flip directions when needed.
    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

}
