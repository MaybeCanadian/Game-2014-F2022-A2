using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*------------------------------
 * TowerPurchoseUIScript.cs - Evan Coffey 101267129
 * 
 * Controls when the tower buy menu is visible
 * 
 * Version History -
 * -10/23/2022 - added script
 * -10/23/2022 - updated the tower button to have a prefab
 * 
 * Latest Revision -
 * 10/23/2022
 * -----------------------------
 */

[System.Serializable]
public struct TowerButton
{
    public string TowerName;
    public int TowerCost;
    public Sprite TowerSprite;
    public bool Active;
    public GameObject TowerPrefab;
}

public class TowerPurchuseUIScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private bool Active = false;
    [SerializeField]
    private GameObject towerUIParent;
    [SerializeField]
    private GameObject OpenButton;
    [Header("Tower Buttons")]
    [SerializeField]
    private List<TowerButtonScript> UITowerButtons;
    [SerializeField]
    private List<TowerButton> buttons;

    public static TowerPurchuseUIScript instance;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void TowerButtonPressed(int index)
    {
        OnClosePress();
        Time.timeScale = 0.0f;
        TowerMakingScript.instance.SpawnTower(buttons[index].TowerPrefab);
    }

    private void Start() //starts with the ui hidden and the open button visible
    {
        towerUIParent.SetActive(false);
        OpenButton.SetActive(true);

        SetUpButtons();
    }

    private void SetUpButtons()
    {
        int it = 0;
        foreach(TowerButtonScript UIButton in UITowerButtons)
        {

            if (buttons[it].Active)
            {
                UIButton.SetTowerButtonActive(true);
                UIButton.SetImage(buttons[it].TowerSprite);
                UIButton.SetTowerCost(buttons[it].TowerCost);
                UIButton.SetTowerName(buttons[it].TowerName);
            }
            else
            {
                UIButton.SetTowerButtonActive(false);
            }

            it++;
        }
    }

    public void SetUIActive(bool input) //currently unused, here if another script would want to change if its open
    {
        Active = input;
    }
    public void OnOpenPress() //connects to the open button on the tower Buy UI
    {
        //Debug.Log("open");
        Active = true;
        towerUIParent.SetActive(true);
        OpenButton.SetActive(false);
    }

    public void OnClosePress() //connects to the close button on the tower Buy UI
    {
        //Debug.Log("close");
        Active = false;
        towerUIParent.SetActive(false);
        OpenButton.SetActive(true);
    }
}
