using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LifeTracker : MonoBehaviour
{
    Player player;
    [SerializeField] Text textField;

    void Start()
    {
        if (player == null)
            player = FindObjectOfType<Player>();
        player.OnLivesChanged += HaveLives_OnLivesChanged;

        if (textField == null)
            textField = GetComponent<Text>();

        textField.text = player.Lives.ToString();
    }

    private void HaveLives_OnLivesChanged(object sender, System.EventArgs e)
    {
        textField.text = player.Lives.ToString();
    }

    private void OnDisable()
    {
        player.OnLivesChanged -= HaveLives_OnLivesChanged;
    }
}
