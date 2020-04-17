using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IPickUpable
{
    public virtual void PickUp(int amountToRestore)
    {
        
    }
}
