using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/*-------------------------------------------------------------------
 * TowerBaseClass.cs - Evan Coffey - 101267129
 * 
 * Base class for all the towers, it will have some base fucntions, all towers will join a controller that can call all their updates
 * 
 * Version History -
 * 10/20/2022 - Created file
 * 
 * Latest Revision -
 * 10/20/2022
 * ------------------------------------------------------------------
 */
[System.Serializable]
public enum TargetingMode
{
    CLOSE,
    FAR,
    MOSTMAXHEALTH,
    LEASTMAXHEALTH,
    MOSTCURRENTHEALTH,
    LEASTCURRENTHEALTH
}


public class TowerBaseClass : MonoBehaviour
{
    [Header("Tower Statistics")]
    public float TowerHealth;
    public float TowerRange;

    [Header("Enemy Layer")]
    public LayerMask EnemyLayerMask;


    //functions to be used by the clas ai
    public Collider2D[] DetectEnemies()
    {
        Collider2D[] allEnemies = Physics2D.OverlapCircleAll(transform.position, TowerRange, EnemyLayerMask);

        //Debug.Log("found " + allEnemies.Length + " enemies");

        return allEnemies;
    }

    public GameObject GetClosestEnemyInRange()
    {
        GameObject Close = null;
        float CloseDistance = Mathf.Infinity;

        foreach(Collider2D enemy in DetectEnemies())
        {
            
            if((transform.position - enemy.transform.position).magnitude < CloseDistance)
            {
                Close = enemy.gameObject;
                CloseDistance = (transform.position - enemy.transform.position).magnitude;
                continue;
            }

        }

        return Close;
    }

    public GameObject GetFarthustEnemy()
    {
        GameObject Far = null;
        float Distance = -1.0f;

        foreach (Collider2D enemy in DetectEnemies())
        {

            if ((transform.position - enemy.transform.position).magnitude > Distance)
            {
                Far = enemy.gameObject;
                Distance = (transform.position - enemy.transform.position).magnitude;
                continue;
            }

        }

        return Far;
    }

    public GameObject GetHighestMaxHealth()
    {
        GameObject Highest = null;
        float mostHealth = 0.0f;

        foreach (Collider2D enemy in DetectEnemies())
        {
            EnemyBaseClass tempEnemyClass = enemy.GetComponent<EnemyBaseClass>();

            if (tempEnemyClass.MaxHealth > mostHealth)
            {
                Highest = enemy.gameObject;
                mostHealth = tempEnemyClass.MaxHealth;
                continue;
            }
        }

        return Highest;
    }

    public GameObject GetLowestMaxHealth()
    {
        GameObject Lowest = null;
        float leastHealth = Mathf.Infinity;

        foreach (Collider2D enemy in DetectEnemies())
        {

            EnemyBaseClass tempEnemyClass = enemy.GetComponent<EnemyBaseClass>();

            if (tempEnemyClass.MaxHealth < leastHealth)
            {
                Lowest = enemy.gameObject;
                leastHealth = tempEnemyClass.MaxHealth;
                continue;
            }
        }

        return Lowest;
    }

    public GameObject GetMaxCurrentHealth()
    {
        GameObject Highest = null;
        float currentHighest = -1.0f;

        foreach (Collider2D enemy in DetectEnemies())
        {

            EnemyBaseClass tempEnemyClass = enemy.GetComponent<EnemyBaseClass>();

            if (tempEnemyClass.CurrentHealth > currentHighest)
            {
                Highest = enemy.gameObject;
                currentHighest = tempEnemyClass.MaxHealth;
                continue;
            }
        }

        return Highest;
    }

    public GameObject GetLowestCurrentHealth()
    {
        GameObject Lowest = null;
        float currentLowest = Mathf.Infinity;

        foreach (Collider2D enemy in DetectEnemies())
        {

            EnemyBaseClass tempEnemyClass = enemy.GetComponent<EnemyBaseClass>();

            if (tempEnemyClass.CurrentHealth < currentLowest)
            {
                Lowest = enemy.gameObject;
                currentLowest = tempEnemyClass.MaxHealth;
                continue;
            }
        }

        return Lowest;
    }

    public virtual void AITick() { }
}
