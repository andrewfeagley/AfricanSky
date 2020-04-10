using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkBehaviour : StateMachineBehaviour
{
    Player player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<Player>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.LookInDirectionMoving();
        player.rigidbody2D.velocity = Move();
        player.CheckForJump();
        player.Attack();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    /// <summary>
    /// This calculates the input of the player times their walkSpeed,
    /// it then normalizes it for proper 2D movement
    /// </summary>
    /// <returns>a new Vector2</returns>
    public Vector2 Move()
    {
        return new Vector2(player.moveHorizontal * player.walkSpeed, player.moveVertical * player.walkSpeed);
    }
}
