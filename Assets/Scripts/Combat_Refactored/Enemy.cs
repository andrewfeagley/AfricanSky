using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IHaveHealth
{
    public Transform playerTransform;
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public LayerMask playerLayers;
    [SerializeField]
    public float walkSpeed;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int maxHealth;

    [HideInInspector]
    public bool isFlipped = false;
    [HideInInspector]
    public bool isMoving = false;
    [HideInInspector]
    public bool isJumpedPressed;
    [HideInInspector]
    public bool isAttackPressed;

    public int Health { get => currentHealth; set => currentHealth = value; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //LookInDirectionMoving();
        //ChasePlayer();
        LookAtPlayer();
    }

    void CheckForDeath()
    {
        if (currentHealth <= 0)
            animator.SetBool(0, true);
    }


    private Vector2 velocity = Vector2.zero;
    void ChasePlayer()
    {
        rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, playerTransform.position, ref velocity, walkSpeed * Time.deltaTime);
    }

    public void LookInDirectionMoving()
    {
        //Checks for input and sets the player to look that way
        if (rigidbody2D.velocity.x > 0 && isFlipped)
        {
            //spriteRenderer.flipX = false;
            Flip();
        }
        else if (rigidbody2D.velocity.x < 0 && !isFlipped)
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

    void LookAtPlayer()
    {
        Vector2 flipped = transform.localScale;
        if(transform.position.x > playerTransform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        if(transform.position.x < playerTransform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
    }

}
