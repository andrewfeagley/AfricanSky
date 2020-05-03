using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] IHaveHealth haveHealth; //should be set in the inspector to either the player or an enemy
    Image Health;
    float Fill;
    [SerializeField] Image slider;

    // Start is called before the first frame update
    void Start()
    {
        if(haveHealth == null)
            haveHealth = FindObjectOfType<Player>();
        //Looks for an event of OnHealthChanged in the IHaveHealth variable
        haveHealth.OnHealthChanged += HaveHealth_OnHealthChanged;

        if (slider == null)
            slider = GetComponent<Image>();

        //Changes the value of the slider to the value of the IHaveHealth variable
        slider.fillAmount = haveHealth.Health / 100;
    }

    private void HaveHealth_OnHealthChanged(object sender, System.EventArgs e)
    {
        slider.fillAmount = haveHealth.Health / 100;
    }
}
