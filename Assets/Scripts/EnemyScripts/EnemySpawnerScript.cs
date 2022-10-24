using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
/*-------------------------------------
 * EnemySpawnerScript.cs - Evan Coffey - 101267129
 * 
 * Spawns the enemeies for the game
 * 
 * Version History -
 * 10/22/2022 - created script and added code to get the enemy prefab from resources
 * 10/22/2022 - set up spawning based on a spawn position, this is made so multiple spawn points can be set up.
 * 10/23/2022 - fixed issue where the parent wasn't being used, now enemies are attached to the parent
 * 10/23/2022 - moved the wave controlling to its own script
 * 
 * Latest Revision -
 * 10/23/2022
 * ------------------------------------
 */
public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField]
    List<Transform> SpawnLocations;

    [SerializeField]
    Transform SpawnParent;

    public static EnemySpawnerScript instance;

    private void Awake() //sets up the single reference
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

    public void SpawnEnemy(GameObject enemy, int LocationIndex) //spawns an enemy with a certain prefab at a certain spawn locations,
                                                                //in first level only inbe spawn, this can change later on with later levels
    {
        GameObject temp = Instantiate(enemy, SpawnLocations[LocationIndex].position, SpawnLocations[LocationIndex].rotation, SpawnParent);
    }
}
