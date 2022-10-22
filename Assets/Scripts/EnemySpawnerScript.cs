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
 * 
 * Latest Revision -
 * 10/22/2022
 * ------------------------------------
 */
public class EnemySpawnerScript : MonoBehaviour
{
    [ReadOnly(true), SerializeField]
    List<GameObject> enemyPrefabs;

    private void Awake()
    {
        enemyPrefabs.Add(Resources.Load<GameObject>("Prefabs/Enemies/Slime"));
    }
}
