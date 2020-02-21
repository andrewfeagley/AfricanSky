using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public EntityState stateInfo;
    Animator anim;

    //Speed in which the Player moves.
    public float walkMoveSpeed;
    private float movementSpeed;

    //Max X and Y movement constraints for Player
    public float xMin, xMax, yMin, yMax;

    private Rigidbody2D rigidBody;

    //Position in which the Player is facing.
    private bool facingRight;

    

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        movementSpeed = walkMoveSpeed;
        stateInfo = GetComponent<EntityState>();
        anim = GetComponent<Animator>();
    }

   
    private void FixedUpdate()
    {
        //-----------Movement--------------------------------------------
        // Collects Player input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Takes the movement of the Player and constraints and implements them into the game.
        Vector2 movement = new Vector2(moveHorizontal,moveVertical);
        rigidBody.velocity = movement * movementSpeed;
        rigidBody.position = new Vector2(Mathf.Clamp(rigidBody.position.x, xMin, xMax), Mathf.Clamp(rigidBody.position.y, yMin, yMax));

        // Flips the direction the Player is looking
        if (moveHorizontal < 0 && !facingRight) {
            Flip();
        }
        else if (moveHorizontal > 0 && facingRight)
        {
            Flip();
        }
        //-----------Attack--------------------------------------------

        //Plays attack animation
        if (Input.GetButton("Fire1"))
        {
            anim.Play("Attack 1");
        }

        //Plays jump animation
        if (Input.GetButton("Jump"))
        {
            anim.Play("Jump");
        }

        if (Input.GetButton("Fire2"))
        {
            anim.Play("Hurt");

        }

        //Plays movement animation
        anim.SetFloat("moveSpeed", rigidBody.velocity.sqrMagnitude);
    }

    //Allows for the Player to flip directions when needed.
    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }    
}
