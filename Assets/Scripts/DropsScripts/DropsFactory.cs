using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropsFactory : MonoBehaviour
{
    List<GameObject> DropsPrefabs;

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
