using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleBehaviour : StateMachineBehaviour
{
    Transform playerTransform;
    Enemy enemy;
    Rigidbody2D rigidbody2D;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindObjectOfType<Player>().transform;
        enemy = animator.GetComponent<Enemy>();
        rigidbody2D = enemy.GetComponent<Rigidbody2D>();
        
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(playerTransform.position.x, playerTransform.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rigidbody2D.position, target, enemy.walkSpeed * Time.fixedDeltaTime);
        //rigidbody2D.MovePosition(newPosition);

        if (Vector2.Distance(playerTransform.position, rigidbody2D.position) <= enemy.attackRange)
        {
            animator.SetTrigger("Punch");
        }

        if (Vector2.Distance(playerTransform.position, rigidbody2D.position) <= enemy.chaseRange)
        {
            animator.SetTrigger("isMoving");
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Punch");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
