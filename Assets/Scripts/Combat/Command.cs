using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    public string CommandName;

    public Command()
    {
        CommandName = "Base Command";
    }

    public virtual void Execute(CombatComponent go)
    {
        this.Log(go);
    }

    protected virtual string Log()
    {
        //log basic command to console
        return $"{this.CommandName} executed";
    }

    protected virtual void Log(CombatComponent go)
    {
        //log basic command to console
        Debug.Log($"{this.Log()} executed on {go.ToString()}");
    }
}
