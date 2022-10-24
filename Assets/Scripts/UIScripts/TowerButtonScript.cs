using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/*-------------------------------------------
 * TowerButtonScript.cs - Evan Coffey - 101267129
 * 
 * Controls the buttons, what thet show and say and talks to the tower spawning script
 * 
 * Version History -
 * 10/23/2022 - created script, stopped working on it for now
 * 
 * Latest Revision -
 * 10/23/2022
 * ------------------------------------------
 */

public class TowerButtonScript : MonoBehaviour
{
    [SerializeField]
    private Image TowerImage;
    [SerializeField]
    private Button TowerButton;
    [SerializeField]
    private TMP_Text TowerName;
    [SerializeField]
    private TMP_Text TowerCost;
    [SerializeField]
    private GameObject TowerButtonParent;
    [SerializeField]
    private int TowerIndex;

    private void Start()
    {
        //TowerIndex = TowerPurchuseUIScript.instance.AddButton(this);  
        //was gonna have them add themselves but to preserve order I'll do it manually
    }

    public void SetTowerButtonActive(bool value)
    {
        TowerButtonParent.SetActive(value);
    }

    public void SetTowerName(string text)
    {
        TowerName.text = text;
    }

    public void SetTowerCost(int cost)
    {
        TowerCost.text = cost.ToString();
    }

    public void SetImage(Sprite image)
    {
        TowerImage.sprite = image;
    }

    public void OnBuyButtonPress()
    {
        TowerPurchuseUIScript.instance.TowerButtonPressed(TowerIndex);
    }
}
