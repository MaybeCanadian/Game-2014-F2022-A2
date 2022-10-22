using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*---------------------------------------
* HealthBar.cs - Evan Coffey - 101267129
* 
* Used to control the healthbar object
* 
* Version History -
* 10/20/2022 - created and set up the basics of the script
* 
* Latets Revision -
* 10/20/2022
* --------------------------------------
*/
public class HealthBar : MonoBehaviour
{
    public float MaxHealth = 100.0f;
    public float CurrentHealth;
    public float CurrentPercent;

    public GameObject HealthSliderCanvas;

    public Slider healthSlider;

    public void Start()
    {
        CurrentHealth = MaxHealth;

        UpdateBar();
    }

    public void SetMaxHealth(float input, bool resetToMax)
    {
        MaxHealth = input;

        if (resetToMax)
            CurrentHealth = MaxHealth;

        UpdateBar();
    }

    public void TakeDamage(float input)
    {
        CurrentHealth -= input;

        UpdateBar();
    }

    private void UpdateBar()
    {

        CurrentPercent = CurrentHealth / MaxHealth;

        if(CurrentPercent == 1.0f)
        {
            HealthSliderCanvas.SetActive(false);
            return;
        }

        HealthSliderCanvas.SetActive(true);

        CurrentPercent = Mathf.Max(CurrentPercent, 0.0f);
        healthSlider.value = CurrentPercent;
    }
}
