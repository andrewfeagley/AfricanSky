using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private float rotationSpeed = 5; //speed of turning
    public bool inSight;
    public GameObject player;
    private Rigidbody2D rigidBody;
    private float movementSpeed;
    public float walkMoveSpeed = 2;
    private bool facingRight;
    public float xMin, xMax, yMin, yMax;

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
        Vector2 direction = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        rigidBody.position = new Vector2(Mathf.Clamp(rigidBody.position.x, xMin, xMax), Mathf.Clamp(rigidBody.position.y, yMin, yMax));

        if (transform.position.x < player.transform.position.x && !facingRight)
        {
            Flip();
        }
        else if (transform.position.x > player.transform.position.x && facingRight)
        {
            Flip();
        }

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

    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

}
