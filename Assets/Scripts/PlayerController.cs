using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkMoveSpeed;
    public float attackMovementSpeed;
    public float xMin, xMax, yMin, yMax;

    AnimatorStateInfo currentStateInfo;
    private float movementSpeed;
    private Rigidbody2D rigidBody;
    Animator anim;
    private bool facingRight;
    private bool facingLeft;

    static int currentState;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        movementSpeed = walkMoveSpeed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal,moveVertical);

        rigidBody.velocity = movement * movementSpeed;
        rigidBody.position = new Vector2(Mathf.Clamp(rigidBody.position.x, xMin, xMax), Mathf.Clamp(rigidBody.position.y, yMin, yMax));

        if (moveHorizontal < 0 && !facingRight) {
            Flip();
        }
        else if (moveHorizontal > 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetButton("Fire1")) {
            anim.Play("Attack 1");
        } 

        if (Input.GetButton("Jump"))
        {
                anim.Play("Jump");
        }


        anim.SetFloat("moveSpeed", rigidBody.velocity.sqrMagnitude);
    }

    private void Flip()
    {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

    }    
}
