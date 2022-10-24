using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*---------------------------------
 * StatTracker.cs - Evan Coffey - 101267129
 * 
 * This script will persist through levels and keep track of the players stats
 * 
 * Version History -
 * 10/24/2022 - created script
 * 10/24/2022 - added too many getters and adders for each stat
 * 
 * Latest Revision -
 * 10/24/2022
 * --------------------------------
 */
public class StatTracker : MonoBehaviour
{
    public static StatTracker instance;

    [SerializeField]
    private int EnemiesKilled;
    [SerializeField]
    private int TowersMade;
    [SerializeField]
    private int HealthLost;
    [SerializeField]
    private int GoldGained;
    [SerializeField]
    private int GoldSpent;
    [SerializeField]
    private int LevelNumber;
    [SerializeField]
    private float TimeKnockedOut;
    [SerializeField]
    private float HealingDone;
    [SerializeField]
    private float DamageDone;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        EnemiesKilled = 0;
        TowersMade = 0;
        HealthLost = 0;
        GoldGained = 0;
        GoldSpent = 0;
        LevelNumber = 0;
        TimeKnockedOut = 0.0f;
        HealingDone = 0.0f;
        DamageDone = 0;
    }

    public void AddEnemyKilled(int value)
    {
        EnemiesKilled += value;
    }

    public int GetEnemyKilled()
    {
        return EnemiesKilled;
    }

    public void AddTowerMade(int value)
    {
        TowersMade += value;
    }
    public int GetTowerMade()
    {
        return TowersMade;
    }

    public void AddHealthLost(int value)
    {
        HealthLost += value;
    }
    public int GetHealthLost()
    {
        return HealthLost;
    }

    public void AddGoldGained(int value)
    {
        GoldGained += value;
    }
    public int GetGoldGained()
    {
        return GoldGained;
    }

    public void AddGoldSpent(int value)
    {
        GoldSpent += value;
    }
    public int GetGoldSpent()
    {
        return GoldSpent;
    }

    public void AddLevel(int value)
    {
        LevelNumber += value;
    }
    public int GetLevel()
    {
        return LevelNumber;
    }

    public void AddTimeKncokedOut(float value)
    {
        TimeKnockedOut += value;
    }
    public float GetTimeKnockedOut()
    {
        return TimeKnockedOut;
    }

    public void AddHealingDone(float value)
    {
        HealingDone += value;
    }
    public float GetHealingDone()
    {
        return HealingDone;
    }

    public void AddDamageDone(float value)
    {
        DamageDone += value;
    }
    public float GetDamageDone()
    {
        return DamageDone;
    }

    public void DeleteThis()
    {
        Destroy(gameObject);
    }
}
