using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] IHaveHealth haveHealth; //should be set in the inspector to either the player or an enemy
    
    [SerializeField] Image image;

    // Start is called before the first frame update
    void Start()
    {
        if(haveHealth == null)
            haveHealth = GetComponentInParent<IHaveHealth>();
        //Looks for an event of OnHealthChanged in the IHaveHealth variable
        haveHealth.OnHealthChanged += HaveHealth_OnHealthChanged;

        if (image == null)
            image = GetComponent<Image>();

        //Changes the value of the slider to the value of the IHaveHealth variable
        image.fillAmount = haveHealth.Health / 100;
    }

    private void HaveHealth_OnHealthChanged(object sender, System.EventArgs e)
    {
        image.fillAmount = haveHealth.Health / 100;
    }
}
