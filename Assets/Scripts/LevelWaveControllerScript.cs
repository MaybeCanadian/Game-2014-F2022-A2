using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
/*------------------------------------------
* LevelWaveControllerScript.cs - Evan Coffey - 101267129
* 
* Keeps track of what needs to be spawned in the waves
* 
* Version History -
* 10/23/2022 - created script
* 10/24/2022 - made connection with stat tracker to increase the level
* 
* Latest Revision -
* 10/24/2022
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

    [Header("Debug Bools")]
    [SerializeField]
    private bool SkipLevel = false;

    private void Start()
    {
        StatTracker.instance.AddLevel(1);
        CurrencyManagerScript.instance.StartNewLevel();
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

        StartCoroutine("WaitForEnemiesToDie"); // waves are done at this point

        yield break;
    }

    private IEnumerator WaitForEnemiesToDie() //we just check when they are all dead
    {
        while(EnemySpawnerScript.instance.GetNumEnmies() > 0)
        {
            yield return null;
        }

        yield return new WaitForSeconds(5.0f);

        LevelFinished();

        yield break;
    }

    private void Update()
    {
        if(SkipLevel)
        {
            LevelFinished();
        }
    }

    private void LevelFinished()
    {
        //SceneManager.LoadScene("Level Select"); //for now we want to go to game win, in full game there would be more levels
        SceneManager.LoadScene("GameWin");
    }
}
