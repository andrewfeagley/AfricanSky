using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    Animator anim;

    //Can collect animation state info.
    public AnimatorStateInfo currentStateInfo;

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

    //Takes the states from the animator window
    //static int walkState = Animator.StringToHash("Base Layer.Move");

    private void Awake()
    {
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
            // Debug.Log("Idle State");
        }

        if (currentState == walkState)
        {
            // Debug.Log("Walk State");
        }

        if (currentState == jumpState)
        {
            // Debug.Log("Jump State");
        }

        if (currentState == deathState)
        {
          //  Debug.Log("Death State");
        }

        if (currentState == hurtState)
        {
           // Debug.Log("Hurt State");
        }

        if (currentState == attackState1)
        {
            //  Debug.Log("Attack State 1");
        }

        if (currentState == attackState2)
        {
            //  Debug.Log("Attack State 2");
        }

        if (currentState == attackState3)
        {
            // Debug.Log("Attack State 3");
        }
    }
}
