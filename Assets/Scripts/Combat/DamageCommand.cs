using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCommand : Command
{
    private float damage;

    public DamageCommand(float Damage)
    {
        this.damage = Damage;
        this.CommandName = "Damage";
    }

    public override void Execute(CombatComponent go)
    {
        go.DamagedBy(damage);
        base.Execute(go);
    }
}
