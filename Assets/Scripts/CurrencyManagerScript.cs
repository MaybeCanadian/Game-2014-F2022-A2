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
 * 10/23/2022 - Removed the starting gold of zero to now start with 50
 * 
 * Latest Revision -
 * 10/23/2022
 * ----------------------------------------------
 */
public class CurrencyManagerScript : MonoBehaviour
{
    [SerializeField]
    private int Gold;
    [SerializeField]
    private int XP;

    public static CurrencyManagerScript instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
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

    public bool UseGold(int value)
    {
        if(Gold >= value)
        {
            Gold -= value;
            return true;
        }

        return false;
    }
}
