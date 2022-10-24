using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIController : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private GameObject HealthPanel;
    [SerializeField]
    private TMP_Text HealthText;
    [Header("XP")]
    [SerializeField]
    private GameObject XPPanel;
    [SerializeField]
    private TMP_Text XPText;
    [Header("Gold")]
    [SerializeField]
    private GameObject GoldPanel;
    [SerializeField]
    private TMP_Text GoldText;

    [Header("Values")]
    private int Health = 100;
    private int Gold = 0;
    private int XP = 0;

    private void Start()
    {
        Gold = CurrencyManagerScript.instance.GetGold();
        XP = CurrencyManagerScript.instance.GetXP();

        UpdateValues();
    }

    public void Update()
    {
        GetNewValues();
        UpdateValues();
    }

    private void GetNewValues()
    {
        Gold = CurrencyManagerScript.instance.GetGold();
        XP = CurrencyManagerScript.instance.GetXP();
    }

    private void UpdateValues()
    {
        HealthText.text = Health.ToString();
        XPText.text = XP.ToString();
        GoldText.text = Gold.ToString();
    }

}
