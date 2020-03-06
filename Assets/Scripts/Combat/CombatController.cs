using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(CombatComponent))]
public class CombatController : MonoBehaviour //like GameComponent
{
    public CombatComponent combatComponent;
    private Rigidbody2D rb;
    private Collider2D collider;

    private EntityState stateInfo;
    Command command = null;

    public float[] attackDamage = { 5, 10, 15 }; //punch, kick, super

    // Start is called before the first frame update
    void Awake()
    {
        InitializeComponents();
        SetCombatStats();
    }

    private void InitializeComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        stateInfo = GetComponent<EntityState>();
        combatComponent = GetComponent<CombatComponent>();
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
                break;
            //add additional cases for different types of enemies
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
