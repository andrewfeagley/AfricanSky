using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int id;
    public int amount;
    public BoxCollider2D hitBoxCollider;

    private void Awake()
    {
        id = 1;
    }
}
