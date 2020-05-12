using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;
using System;
using Object = UnityEngine.Object;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] static TMP_Text score;
    

    public static int enemiesKilled;
    public static int totalEnemiesKilled = 0;
    // Update is called once per frame

    [MenuItem("Tools/Write file")]
    static void WriteString()
    {
        string path = "Assets/Resources/text.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(totalEnemiesKilled);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        //string textLoad = Resources.Load("text.txt").ToString();
        TextAsset asset = Resources.GetBuiltinResource<TextAsset>(path);

        //Print the text from the file
        //Debug.Log(asset.text);
        score.text = "Score: " + asset.text;
    }


    private void OnLevelWasLoaded(int level)
    {
        if(level == 3)
        {
            
           
        }
    }

    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string path = "Assets/Resources/text.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        score.text = reader.ReadLine();
        reader.Close();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            ReadString();
        }
        else
        {
            WriteString();
        }

        Debug.Log(CameraController.isFollowing);

    }
    void FixedUpdate()
    {
        if (enemiesKilled == 6 && CameraController.isFollowing == false) {
            CameraController.isFollowing = true;
            Tutorial.gosign.SetActive(true);
            enemiesKilled = 0;
        }

        if (totalEnemiesKilled >= 18) {
            SceneManager.LoadScene("WinScene");
        }

        if (PlayerController.lives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
