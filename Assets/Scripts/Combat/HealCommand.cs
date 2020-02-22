using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCommand : Command
{
    private float health;

    public HealCommand(float heal)
    {
        health = heal;
        this.CommandName = "Heal";
    }

    public override void Execute(CombatComponent go)
    {
        go.HealedBy(health);
        base.Execute(go);
    }
}
