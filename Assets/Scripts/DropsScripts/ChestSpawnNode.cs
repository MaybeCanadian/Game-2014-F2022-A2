using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawnNode : MonoBehaviour
{
    private void Start()
    {
        ChestSpawnerScript.instance.AddSpawnLocation(transform);
    }
}
