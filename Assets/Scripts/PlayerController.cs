using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Speed in which the Player moves.
    public float walkMoveSpeed;
    private float movementSpeed;

    //Max X and Y movement constraints for Player
    public float xMin, xMax, yMin, yMax;

    private Rigidbody2D rigidBody;
    Animator anim;

    //Position in which the Player is facing.
    private bool facingRight;
    private bool facingLeft;

    //Can collect animation state info.
    AnimatorStateInfo currentStateInfo;

    //Checks to see what the current state the Player is in
    static int currentState;

    //Takes the states from the animator window
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int walkState = Animator.StringToHash("Base Layer.Walk");
    static int attackState1 = Animator.StringToHash("Base Layer.Attack 1");
    static int attackState2 = Animator.StringToHash("Base Layer.Attack 2");
    static int attackState3 = Animator.StringToHash("Base Layer.Attack 3");
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    static int deathState = Animator.StringToHash("Base Layer.Death");
    static int hurtState = Animator.StringToHash("Base Layer.Hurt");

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        movementSpeed = walkMoveSpeed;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //currentStateInfo will equal the info in the animator Base Layer
        currentStateInfo = anim.GetCurrentAnimatorStateInfo(0);

        //Takes current State info and converts it into an integer code
        currentState = currentStateInfo.fullPathHash;

        //Checks to see what state the Player is in and then runs code inside the condition
        if (currentState == idleState)
        {
           Debug.Log("Idle State");
        }

        if (currentState == walkState)
        {
          Debug.Log("Walk State");
        }

        if (currentState == jumpState)
        {
           Debug.Log("Jump State");
        }

        if (currentState == deathState)
        {
            Debug.Log("Death State");
        }

        if (currentState == hurtState)
        {
            Debug.Log("Hurt State");
        }

        if (currentState == attackState1)
        {
           Debug.Log("Attack State 1");
        }

        if (currentState == attackState2)
        {
            Debug.Log("Attack State 2");
        }

        if (currentState == attackState3)
        {
            Debug.Log("Attack State 3");
        }
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
