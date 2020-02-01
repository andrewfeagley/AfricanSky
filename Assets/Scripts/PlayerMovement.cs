using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int Movespeed = 0;

    float horizontal;
    float vertical;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontal * Movespeed, vertical * Movespeed, 0.0f);
        transform.position = transform.position + movement * Time.deltaTime;
    }
}
