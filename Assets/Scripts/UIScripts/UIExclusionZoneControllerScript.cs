using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
/*--------------------------------------
 * UIExclusionZoneControllerScript.cs - Evan Coffey - 101267129
 * 
 * Keeps track of where and when the mobile input can be used to control the player. Basically it will stop the player from taking input when tapping on buttons
 * or when a menu is opened.
 * 
 * Version History -
 * 10/23/2022 - script made
 * 
 * Latest Revision -
 * 10/23/2022
 * -------------------------------------
 */
public class UIExclusionZoneControllerScript : MonoBehaviour
{
    private bool MenuOpen = false;

    public static UIExclusionZoneControllerScript instance;

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

    public bool GetMenuOpen()
    {
        return MenuOpen;
    }
}
