using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStop : MonoBehaviour
{
    public GameObject otherObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks to see if the otherObject has the specified tag and if so, deactivitates the object and turns isFollowing false.
        if (otherObject.tag == "CameraMidPoint")
        {
            otherObject = otherObject.transform.parent.gameObject;
            otherObject.GetComponent<CameraController>().isFollowing = false;
            gameObject.SetActive(false);
        }
        
    }
}
