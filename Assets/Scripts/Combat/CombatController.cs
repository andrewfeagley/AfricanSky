using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(CombatComponent))]
public class CombatController : MonoBehaviour //like GameComponent
{
    Animator anim;
    public CombatComponent combatComponent;
    private Rigidbody2D rb;
    //private Collider2D collider;

    private EntityState stateInfo;
    Command command = null;
    EnemyController enemyController;

    public float[] attackDamage = { 5, 10, 15 }; //punch, kick, super

    // Start is called before the first frame update
    void Awake()
    {
        InitializeComponents();
        SetCombatStats();
    }

    private void InitializeComponents()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //collider = GetComponent<Collider2D>();
        stateInfo = GetComponent<EntityState>();
        combatComponent = GetComponent<CombatComponent>();
        enemyController = GetComponent<EnemyController>();
    }

    void SetCombatStats()
    {

        switch (gameObject.tag) //depending on what kind of entity this is
        {
            case "Player":
                //set damage/health
                break;
            case "Enemy":
                //set damage/health
                InvokeRepeating("RandomAttack", 1f, 5f);
                break;
            //add additional cases for different types of enemies
        }
    }

    public void RandomAttack()
    {
        int randomAttack = Random.Range(0, 3);

        //if (enemyController.inSight) //if player is in sight
        {
            switch (randomAttack)
            {
                case 0:
                    anim.Play("Attack 1");
                    break;
                case 1:
                    anim.Play("Attack 2");
                    break;
                case 2:
                    anim.Play("Attack 3");
                    break;
                default:
                    anim.Play("Idle");
                    break;
            }
            Debug.Log($"{gameObject.name} attacked");
        }
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        AnimatorStateInfo state = stateInfo.currentStateInfo; //get current state from player controller's animator

        command = null;

        if (state.IsName("Attack 1"))
        {
            command = new DamageCommand(attackDamage[0]);
        }
        else if (state.IsName("Attack 2"))
        {
            command = new DamageCommand(attackDamage[1]);
        }
        else if (state.IsName("Attack 3"))
        {
            command = new DamageCommand(attackDamage[2]);
        }

        if (command != null)
        {
            command.Execute(col.gameObject.GetComponent<CombatComponent>()); //can we do this without a get component?
        }
    }

}
