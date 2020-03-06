using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    //Speed in which the Player moves.
    public float walkMoveSpeed;
    private float movementSpeed;
    private static int lives = 3;

    //Max X and Y movement constraints for Player
    public float xMin, xMax, yMin, yMax;

    private Rigidbody2D rigidBody;
    public GameObject attackBox1, attackBox2, attackBox3;
    public Sprite attack1Hitframe, attack2Hitframe, attack3Hitframe;
    SpriteRenderer currentSprite;

    //Position in which the Player is facing.
    private bool facingRight;

    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        movementSpeed = walkMoveSpeed;
        //stateInfo = GetComponent<EntityState>();
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

        if (Input.GetButton("Fire2"))
        {
            anim.Play("Attack 2");
        }

        if (Input.GetButton("Fire3"))
        {
            anim.Play("Attack 3");
        }

        //Checks to see if the attack frame is equal to the current in-game frame and runs code.
        if (attack1Hitframe == currentSprite.sprite)
        {
            attackBox1.gameObject.SetActive(true);
        }
        else {
            attackBox1.gameObject.SetActive(false);
        }

        if (attack2Hitframe == currentSprite.sprite)
        {
            attackBox2.gameObject.SetActive(true);
        }
        else
        {
            attackBox2.gameObject.SetActive(false);
        }

        if (attack3Hitframe == currentSprite.sprite)
        {
            attackBox3.gameObject.SetActive(true);
        }
        else
        {
            attackBox3.gameObject.SetActive(false);
        }

        //Plays jump animation
        if (Input.GetButton("Jump"))
        {
            anim.Play("Jump");
        }

       //if (Input.GetButton("Fire3"))
        //{
         //   lives = lives - 1;
          //  Debug.Log(lives);
       // }

        //if (lives <= 0) {
        //    SceneManager.LoadScene("LoseScene");
      //  }

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
