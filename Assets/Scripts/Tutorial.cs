﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static int enemiesKilled;

    private void FixedUpdate()
    {
            CameraController.isFollowing = true;
    }
}
