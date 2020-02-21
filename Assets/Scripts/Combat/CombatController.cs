using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CombatController : MonoBehaviour //like GameComponent
{
    public CombatComponent combatComponent;
    private Rigidbody2D rb;
    private Collider2D collider;

    public EntityState stateInfo;
    Command command = null;

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
    }

    void SetCombatStats()
    {
        switch (gameObject.tag) //depending on what kind of entity this is
        {
            case "Player":
                combatComponent = new CombatComponent(100, 5, 10, 15);
                break;
            case "Enemy":
                combatComponent = new CombatComponent(50, 1, 5, 10);
                break;
            //add additional cases for different types of enemies
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        AnimatorStateInfo state = stateInfo.currentStateInfo; //get current state from player controller's animator

        CombatController eCombat = col.gameObject.GetComponent<CombatController>();
        AnimatorStateInfo estate = eCombat.stateInfo.currentStateInfo; //dont want to call getcomponent in collision

        command = null;

        if (estate.IsName("Attack 1"))
        {
            command = new DamageCommand(eCombat.combatComponent.attackDamage[0]);
        }
        else if (estate.IsName("Attack 2"))
        {
            command = new DamageCommand(eCombat.combatComponent.attackDamage[1]);
        }
        else if (estate.IsName("Attack 3"))
        {
            command = new DamageCommand(eCombat.combatComponent.attackDamage[2]);
        }
    }

    private void Update()
    {
        if (command != null)
        {
            command.Execute(combatComponent);
        }
    }

}
