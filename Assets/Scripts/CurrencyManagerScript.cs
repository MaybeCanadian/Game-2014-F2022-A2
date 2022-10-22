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
 * 
 * Latest Revision -
 * 10/22/2022
 * ----------------------------------------------
 */
public class CurrencyManagerScript : MonoBehaviour
{
    public int Gold;
    public float XP;

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
    }

    public void AddGold(int value)
    {
        Gold += value;
    }

    public void AddXP(float value)
    {
        XP += value;
    }
}
