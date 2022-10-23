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
 * 10/23/2022 - added script
 * 
 * Latest Revision -
 * 10/23/2022
 * -----------------------------
 */
public class TowerPurchuseUIScript : MonoBehaviour
{
    [SerializeField]
    private bool Active = false;
    [SerializeField]
    private GameObject towerUIParent;
    [SerializeField]
    private GameObject OpenButton;

    private void Start()
    {
        towerUIParent.SetActive(false);
        OpenButton.SetActive(true);
    }

    public void SetUIActive(bool input)
    {
        Active = input;
    }
    public void OnOpenPress()
    {
        Debug.Log("open");
        Active = true;
        towerUIParent.SetActive(true);
        OpenButton.SetActive(false);
    }

    public void OnClosePress()
    {
        Debug.Log("close");
        Active = false;
        towerUIParent.SetActive(false);
        OpenButton.SetActive(true);
    }
}
