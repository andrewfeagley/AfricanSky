using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public Transform playerTransform;
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public LayerMask enemyLayers;
    [SerializeField]
    public float walkSpeed;
    int lives = 3;
    public int health;

    [HideInInspector]
    public bool isFlipped = false;
    [HideInInspector]
    public bool isMoving = false;
    [HideInInspector]
    public bool isDead = false;
    [HideInInspector]
    public float moveHorizontal;
    [HideInInspector]
    public float moveVertical;
    [HideInInspector]
    public bool isJumpedPressed;
    [HideInInspector]
    public bool isAttackPressed;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
        CheckForMovement();
        CheckForDeath();
    }

    void HandleInput()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        isJumpedPressed = Input.GetKeyDown(KeyCode.Space);
        isAttackPressed = Input.GetKeyDown(KeyCode.Z);
    }

    public void Attack()
    {
        if(isAttackPressed)
            animator.SetBool("Punch", true);
    }

    public void CheckForJump()
    {
        if (isJumpedPressed)
            animator.SetBool("Jump", true);
    }

    void CheckForMovement()
    {
        if (moveHorizontal == 0 && moveVertical == 0)
            isMoving = false;
        else if(moveHorizontal != 0 || moveVertical != 0)
            isMoving = true;
        animator.SetBool("IsMoving", isMoving);
    }

    /// <summary>
    /// This sets the player sprite to face the direction the player is moving
    /// </summary>
    public void LookInDirectionMoving()
    {
        //Checks for input and sets the player to look that way
        if(rigidbody2D.velocity.x > 0 && isFlipped)
        {
            //spriteRenderer.flipX = false;
            Flip();
        }
        else if(moveHorizontal < 0 && !isFlipped)
        {
            //spriteRenderer.flipX = true;
            Flip();
        }
    }

    void Flip()
    {
        isFlipped = !isFlipped;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void CheckForDeath()
    {
        if(health <= 0)
        {
            health = 0;
            isDead = true;
        }
        else if (health > 0)
            isDead = false;
        animator.SetBool("IsDead", isDead);
    }
}
