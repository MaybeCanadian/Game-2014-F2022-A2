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
 * 
 * Latest Revision -
 * 10/22/2022
 * ------------------------------------
 */
public class EnemySpawnerScript : MonoBehaviour
{
    [ReadOnly(true), SerializeField]
    List<GameObject> enemyPrefabs;

    [SerializeField]
    List<Transform> SpawnLocations;

    [SerializeField]
    Transform SpawnParent;

    private void Start()
    {
        StartCoroutine("WaveController");
    }

    private IEnumerator WaveController()
    {

        while(true)
        {
            SpawnEnemy(enemyPrefabs[0], SpawnLocations[0]);

            yield return new WaitForSeconds(1.0f);
        }

        yield return null;
    }

    private void SpawnEnemy(GameObject enemy, Transform spawnLocation)
    {
        GameObject temp = Instantiate(enemy, spawnLocation.position, spawnLocation.rotation);
    }
}
