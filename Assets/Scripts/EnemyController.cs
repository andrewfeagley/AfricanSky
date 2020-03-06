using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyController : MonoBehaviour
{

    //used to check whether the Player is in sight of Enemy
    public bool inSight;
    int enemiesDead = 1;
    public GameObject player;
    private Rigidbody2D rigidBody;
    Animator anim;

    //Speed in which the Enemy moves.
    private float movementSpeed;
    public float walkMoveSpeed = 2;

    //Position in which the Enemy is facing.
    private bool facingRight;
    private bool facingLeft;

    //Max X and Y movement constraints for Enemy
    public float xMin, xMax, yMin, yMax;

    public GameObject target;
    private GameObject frontTarget;
    private GameObject backTarget;
    public float targetDistance;
    public float frontTargetDistance;
    public float backTargetDistance;

    //Can collect animation state info.
    AnimatorStateInfo currentStateInfo;

    //Checks to see what the current state the Enemy is in
    static int currentState;

    //Takes the states from the animator window
    static int walkState = Animator.StringToHash("Base Layer.Move");

    void Awake()
    {
        //Searches for the object with the Player tag
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

        rigidBody = GetComponent<Rigidbody2D>();
        movementSpeed = walkMoveSpeed;

        frontTarget = GameObject.Find("Enemy Front Target");
        backTarget = GameObject.Find("Enemy Back Target");
    }

    private void Update()
    {
        //currentStateInfo will equal the info in the animator Base Layer
        currentStateInfo = anim.GetCurrentAnimatorStateInfo(0);

        //Takes current State info and converts it into an integer code
        currentState = currentStateInfo.fullPathHash;

        //Checks to see what state the Player is in and then runs code inside the condition

        if (currentState == walkState)
        {
            Debug.Log("Walk State");
        }
    }
    void FixedUpdate()
    {

        //Finds and follows the players position while keeping the Enemy in X and Y constraints
        Vector2 direction = player.transform.position - transform.position;
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
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

        frontTargetDistance = Vector3.Distance(frontTarget.transform.position, gameObject.transform.position);
        backTargetDistance = Vector3.Distance(backTarget.transform.position, gameObject.transform.position);

        if (frontTargetDistance < backTargetDistance) {
            target = frontTarget;
            transform.position = Vector2.MoveTowards(transform.position, frontTarget.transform.position, movementSpeed * Time.deltaTime);
        } else if (frontTargetDistance > backTargetDistance) {
            target = backTarget;
            transform.position = Vector2.MoveTowards(transform.position, backTarget.transform.position, movementSpeed * Time.deltaTime);
        }

        targetDistance = Vector3.Distance(target.transform.position, gameObject.transform.position);

        
    }

    // Activates as the Player enters the inSight trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            inSight = true;
            Destroy(gameObject);
           // enemiesDead = 0;
            
           // if (enemiesDead <=0) {
           // SceneManager.LoadScene("WinScene");
       // }
        }
    }

    // deactivates as the Player exits the inSight trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
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
