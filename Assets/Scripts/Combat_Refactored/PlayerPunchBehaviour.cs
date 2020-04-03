using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPunchBehaviour : StateMachineBehaviour
{
    Player player;
    PlayerCombat playerCombat;
    UnityEvent hitConnected;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<Player>();
        playerCombat = animator.GetComponent<PlayerCombat>();
        player.rigidbody2D.velocity = Vector2.zero;
        animator.SetBool("Punch", false);
    }
    
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.rigidbody2D.velocity = Vector2.zero;

        //Checks to see if the Attack Animation's HITBOX is hitting an enemy
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerCombat.attackPoint.position, playerCombat.attackRange, playerCombat.enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit " + enemy.name);
        }
    }
    

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
