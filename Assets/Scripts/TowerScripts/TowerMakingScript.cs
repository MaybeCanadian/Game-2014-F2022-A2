using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMakingScript : MonoBehaviour
{
    public static TowerMakingScript instance;

    [SerializeField]
    private Transform TowerParent;

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

    public void SpawnTower(GameObject prefab)
    {
        GameObject Tower = Instantiate(prefab, TowerParent);
        Tower.transform.position = new Vector3(0, 0, 0);
    }
}
