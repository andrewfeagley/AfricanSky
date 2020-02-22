using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject[] eArray;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eArray = GameObject.FindGameObjectsWithTag("Enemy");

        if (eArray.Length == 0) {
            CameraController.isFollowing = true;
        }
    }
}
