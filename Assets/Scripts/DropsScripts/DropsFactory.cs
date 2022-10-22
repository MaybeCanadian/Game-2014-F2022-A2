using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*-------------------------------------------
 * DropsFactory.cs - Evan Coffey - 101267129
 * 
 * Keeps track of the Drop prefabs and makes them for the manager
 * 
 * Version History -
 * 10/22/2022 - created script and added the createDropFunction
 * 
 * Latest Revision -
 * 10/22/2022
 * ------------------------------------------
 */

[System.Serializable]
public class DropsFactory : MonoBehaviour
{
    public List<GameObject> DropsPrefabs;

    public Transform DropsParent;

    public static DropsFactory instance;

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

    public GameObject CreateDrop(DropTypes type)
    {
        GameObject drop = Instantiate(DropsPrefabs[((int)type)], DropsParent);
        drop.SetActive(false);

        return drop;
    }
}
