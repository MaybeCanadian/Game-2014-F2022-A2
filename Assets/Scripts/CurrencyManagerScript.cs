using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*-----------------------------------------------
 * CurrencyManagerScript.cs - Evan Coffey - 101267129
 * 
 * Keeps track of the players experiance and gold
 * 
 * Version History -
 * 10/22/2022 - created script
 * 10/23/2022 - added functions that give the gold and XP values of the player for the UI
 * 
 * Latest Revision -
 * 10/22/2022
 * ----------------------------------------------
 */
public class CurrencyManagerScript : MonoBehaviour
{
    public int Gold;
    public int XP;

    public static CurrencyManagerScript instance;

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

        Gold = 0;
        XP = 0;
    }

    public void StartNewLevel()
    {
        XP = 0;
    }

    public void AddGold(int value)
    {
        Gold += value;
    }

    public void AddXP(int value)
    {
        XP += value;
    }

    public int GetGold()
    {
        return Gold;
    }

    public int GetXP()
    {
        return XP;
    }
}
