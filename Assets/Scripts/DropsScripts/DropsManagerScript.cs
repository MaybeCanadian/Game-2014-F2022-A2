using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
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
    Queue<GameObject> DropPool;

    [SerializeField]
    private int StartingDropNumber = 50;
    [SerializeField, ReadOnly(true)]
    private int activeDrops = 0;
    [SerializeField, ReadOnly(true)]
    private int remainingDrops = 0;

    public static DropsManagerScript instance;

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

    private void Start()
    {
        DropPool = new Queue<GameObject>();
        BuildItemPool(DropTypes.GoldBag);
    }

    private void BuildItemPool(DropTypes type)
    {
        for(int i = 0; i < StartingDropNumber; i++)
        {
            CreateDrop(type);
        }

        remainingDrops = DropPool.Count;
    }

    private void CreateDrop(DropTypes type)
    {
        GameObject TempDrop = DropsFactory.instance.CreateDrop(type);
        DropPool.Enqueue(TempDrop);
    }

    public GameObject GetDrop(DropTypes drop)
    {
        if(DropPool.Count <= 0)
        {
            CreateDrop(drop);
        }

        GameObject tempDrop = DropPool.Dequeue();
        tempDrop.SetActive(true);

        activeDrops++;

        return tempDrop;    
    }

    public void ReturnDrop(GameObject input)
    {
        input.SetActive(false);
        DropPool.Enqueue(input);

        remainingDrops = DropPool.Count;
    }
}
