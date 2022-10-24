using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/*-------------------------------------
 * ScoreUIController.cs - Evan Coffey - 101267129
 * 
 * Handles showing the proper values for the health, gold and XP
 * 
 * Version History -
 * 10/23/2022 - created script
 * 
 * Latest Revision -
 * -10/23/2022
 * ------------------------------------
 */
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
        Health = LevelHealthController.instance.GetHealth();

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
        Health = LevelHealthController.instance.GetHealth();
    }

    private void UpdateValues()
    {
        HealthText.text = Health.ToString();
        XPText.text = XP.ToString();
        GoldText.text = Gold.ToString();
    }

}
