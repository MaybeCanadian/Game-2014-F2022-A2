using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
/*------------------------------------------
* LevelWaveControllerScript.cs - Evan Coffey - 101267129
* 
* Keeps track of what needs to be spawned in the waves
* 
* Version History -
* 10/23/2022 - created script
* 
* Latest Revision -
* 10/23/2022
* -----------------------------------------
*/
[System.Serializable]
public struct waveEnemies //this is an enemy cluster
{
    public GameObject EnemyPrefab;
    public int numToSpawn;
    public int SpawnLocationToUse;
    public float TimeBetweenSpawns;
    public float TimeUntilNextGroup;
}

[System.Serializable]
public struct wave //the waves in the game
{
    public List<waveEnemies> enemiesInWave; //the clusters of enemies in the wave
    public float TimeBeforeNextWave;
}

public class LevelWaveControllerScript : MonoBehaviour
{
    [SerializeField]
    public List<wave> LevelWaves;

    [SerializeField, ReadOnly(true)]
    private int CurrentWave = 0;
    [SerializeField, ReadOnly(true)]
    private int EnemyInWave = 0;
    [SerializeField, ReadOnly(true)]
    private int EnemySpawnIt = 0;

    private void Start()
    {
        CurrencyManagerScript.instance.StartNewLevel();
        StartCoroutine("SpawnWaves");
    }

    private IEnumerator SpawnWaves() //spawns the enemies in the waves
    {
        while(CurrentWave < LevelWaves.Count) //we check we have a wave to spawn
        {
            Debug.Log("Starting Wave " + CurrentWave);
            EnemyInWave = 0;

            wave WaveCurrent = LevelWaves[CurrentWave];

            while (EnemyInWave < WaveCurrent.enemiesInWave.Count) //we check we have clusters
            {
                EnemySpawnIt = 0;

                waveEnemies enemy = LevelWaves[CurrentWave].enemiesInWave[EnemyInWave];

                while (EnemySpawnIt < enemy.numToSpawn) //we spawn the enmeies in the cluster
                {
                    EnemySpawnerScript.instance.SpawnEnemy(enemy.EnemyPrefab, enemy.SpawnLocationToUse);
                    EnemySpawnIt++;

                    yield return new WaitForSeconds(enemy.TimeBetweenSpawns);
                }
                EnemyInWave++;

                yield return new WaitForSeconds(enemy.TimeUntilNextGroup);
            }

            yield return new WaitForSeconds(WaveCurrent.TimeBeforeNextWave);

            CurrentWave++;
        }

        yield break;
    }

}
