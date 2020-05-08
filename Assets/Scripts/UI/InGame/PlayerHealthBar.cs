using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : HealthBar
{
    [SerializeField]
    Player player; //should be set in the inspector to either the player or an enemy
    Image imageFill;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = FindObjectOfType<Player>();

        player.OnHealthChanged += Player_OnHealthChanged;

        if (imageFill == null)
            imageFill = GetComponent<Image>();

        imageFill.fillAmount = player.Health / 100;
    }

    private void Player_OnHealthChanged(object sender, System.EventArgs e)
    {
        imageFill.fillAmount = player.Health / 100;
    }
}
