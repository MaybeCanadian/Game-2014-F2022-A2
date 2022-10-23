using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    [SerializeField, Tooltip("The max health of the object")]
    private float MaxHealth = 100.0f;
    [SerializeField, ReadOnly(true)]
    private float CurrentHealth;
    [SerializeField, ReadOnly(true)]
    private float CurrentPercent;
    [SerializeField, Tooltip("The health gained per second")]
    private float HealthRegen = 1.0f;

    [SerializeField, ReadOnly(true)]
    private bool IsDead = false;

    [SerializeField]
    private GameObject HealthSliderObject;
    [SerializeField]
    private Slider healthSlider;

    public void Start()
    {
        CurrentHealth = MaxHealth;

        UpdateBar();
    }
    private void Update()
    {
        if (CurrentHealth < MaxHealth)
        {
            CurrentHealth += HealthRegen * Time.deltaTime;

            CurrentHealth = Mathf.Min(CurrentHealth, MaxHealth);

            UpdateBar();
        }
    }

    public float GetCurrentHealth()
    {
        return CurrentHealth;
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
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

        if(CurrentHealth <= 0)
        {
            IsDead = true;
        }

        UpdateBar();
    }

    public bool GetIsDead()
    {
        return IsDead;
    }

    private void UpdateBar()
    {

        CurrentPercent = CurrentHealth / MaxHealth;

        if(CurrentPercent == 1.0f)
        {
            HealthSliderObject.SetActive(false);
            return;
        }

        HealthSliderObject.SetActive(true);

        CurrentPercent = Mathf.Max(CurrentPercent, 0.0f);
        healthSlider.value = CurrentPercent;
    }
}
