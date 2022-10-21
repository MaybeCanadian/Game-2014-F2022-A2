using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*---------------------------------------
 * TowerManagerScript.cs - Evan Coffey - 101267129
 * 
 * Keeps track of all the towers and runs their AI when needed
 * 
 * Version History -
 * 10/20/2022 - created class and set up the list as well as the the addtower function
 * 
 * Latest Revision -
 * 10/20/2022
 * --------------------------------------
 */
[System.Serializable]
public class TowerManagerScript : MonoBehaviour
{
    List<TowerBaseClass> towers;

    public static TowerManagerScript instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AddTower(TowerBaseClass input)
    {
        Debug.Log("starting add");
        towers.Add(input);
        Debug.Log("tower added");
    }

    private void Update()
    {
        //foreach(TowerBaseClass tower in towers)
        //{
        //    //tower.AITick();
        //}
    }
}
