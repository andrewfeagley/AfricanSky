using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameQuit : MonoBehaviour
{

    private GameObject gameMenu;

    private void Start()
    {
        gameMenu = GameObject.Find("Canvas");
        gameMenu.SetActive(true);
    }
    void FixedUpdate()
    {
        if (Input.GetButton("Quit"))
        {
            gameMenu.SetActive(true);
        }
        else if(Input.GetButton("MenuExit"))
        {
            gameMenu.SetActive(false);
        }
    }
}