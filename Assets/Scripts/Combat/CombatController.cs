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

    public float[] attackDamage = {5, 10, 15}; //punch, kick, super

    // Start is called before the first frame update
    void Awake()
    {
        InitializeComponents();    
    }

    private void InitializeComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        stateInfo = GetComponent<EntityState>();
        combatComponent = new CombatComponent();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        AnimatorStateInfo state = stateInfo.currentStateInfo; //get current state from player controller's animator

        if (state.IsName("Attack 1"))
        {
            
        }
        else if (state.IsName("Attack 2"))
        {

        }
        else if (state.IsName("Attack 3"))
        {

        }

    }
}
