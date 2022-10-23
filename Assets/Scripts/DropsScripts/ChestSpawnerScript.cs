using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*--------------------------------------------
 * ChestSpawnerScript.cs - Evan Coffey - 101267129
 * 
 * Makes chests appear in certain spots on the map that the player can collect
 * 
 * Version History -
 * 10/23/2022 - created script
 * 
 * Latest Revsision -
 * 10/23/2022
 * -------------------------------------------
 */
[System.Serializable]
public class ChestSpawnerScript : MonoBehaviour
{
    [Header("Chest Spawn Information")]
    [SerializeField]
    private  GameObject ChestPrefab;
    [SerializeField]
    private List<GameObject> ChestList;
    [SerializeField]
    private List<Transform> ChestSpawnLocations;
    [SerializeField]
    private Transform ChestParent;

    [Header("Chest Spawn Values")]
    [SerializeField]
    private float MinSpawnTime = 30.0f;
    [SerializeField]
    private float MaxSpawnTime = 60.0f;

    public static ChestSpawnerScript instance;

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

    private void Start()
    {
        Invoke("SpawnChest", Random.Range(MinSpawnTime, MaxSpawnTime));
    }

    public void AddSpawnLocation(Transform SpawnLocation)
    {
        ChestSpawnLocations.Add(SpawnLocation);
    }

    private void SpawnChest()
    {
        GameObject chest = Instantiate(ChestPrefab, ChestParent);
        chest.transform.position = ChestSpawnLocations[Random.Range(0, ChestSpawnLocations.Count)].transform.position;

        Invoke("SpawnChest", Random.Range(MinSpawnTime, MaxSpawnTime));
    }
}
