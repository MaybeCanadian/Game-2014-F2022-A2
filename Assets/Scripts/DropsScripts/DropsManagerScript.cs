using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
/*----------------------------------
 * DropsManagerScript.cs - Evan Coffey - 101267129
 * 
 * Keeps all drops loaded up and can give them out when needed
 * 
 * Version History -
 * 10/22/2022 - created script
 * 
 * Latest Revision -
 * 10/22/2022
 * ---------------------------------
 */
[System.Serializable]
public enum DropTypes
{
    GoldBag,
    Experiance
}

public class DropsManagerScript : MonoBehaviour
{
    Queue<GameObject> DropPools;

    [SerializeField]
    private int startingGoldNumber = 50;
    [SerializeField, ReadOnly(true)]
    private int activeGoldDrops = 0;
    [SerializeField, ReadOnly(true)]
    private int remainingGoldDrops = 0;

    private void Start()
    {
        
    }

    private void BuildItemPool(DropTypes type)
    {
        
    }
}
