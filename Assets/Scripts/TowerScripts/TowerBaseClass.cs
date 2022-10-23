using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
/*-------------------------------------------------------------------
 * TowerBaseClass.cs - Evan Coffey - 101267129
 * 
 * Base class for all the towers, it will have some base fucntions, all towers will join a controller that can call all their updates
 * 
 * Version History -
 * 10/20/2022 - Created file
 * 10/21/2022 - Updated with some headers and Tooltips
 * 
 * Latest Revision -
 * 10/21/2022
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
    [Tooltip("The Health of the Tower"), SerializeField]
    protected float TowerHealth;
    [Header("How far the Tower Detects Enemies"), SerializeField]
    protected float TowerRange;
    [Range(0.01f, 200.0f), Tooltip("Attacks per seccond"), SerializeField]
    protected float AttackSpeed;
    [Tooltip("If the Tower Can Attack"), ReadOnly(true), SerializeField]
    protected bool AttackCoolDown = false;
    [Tooltip("If Tower has a target"), ReadOnly(true), SerializeField]
    protected bool TowerHasTarget = false;

    [Header("Enemy Layer")]
    public LayerMask EnemyLayerMask;

    protected GameObject towerTarget;

    [SerializeField, ReadOnly(true)]
    protected float Damage = 10.0f;

    private void Start()
    {
        AttackCoolDown = false;
        TowerHasTarget = false;
        towerTarget = null;
    }

    protected void ResetAttackCoolDown()
    {
        AttackCoolDown = false;
    }

    //functions to be used by the clas ai
    protected Collider2D[] DetectEnemies()
    {
        Collider2D[] allEnemies = Physics2D.OverlapCircleAll(transform.position, TowerRange, EnemyLayerMask);

        return allEnemies;
    }

    protected GameObject GetClosestEnemyInRange()
    {
        GameObject Close = null;
        float CloseDistance = Mathf.Infinity;

        foreach(Collider2D enemy in DetectEnemies())
        {
            
            if(DistanceToTarget(enemy.gameObject) < CloseDistance)
            {
                Close = enemy.gameObject;
                CloseDistance = (transform.position - enemy.transform.position).magnitude;
                continue;
            }

        }

        return Close;
    }

    protected GameObject GetFarthustEnemy()
    {
        GameObject Far = null;
        float Distance = -1.0f;

        foreach (Collider2D enemy in DetectEnemies())
        {

            if (DistanceToTarget(enemy.gameObject) > Distance)
            {
                Far = enemy.gameObject;
                Distance = (transform.position - enemy.transform.position).magnitude;
                continue;
            }

        }

        return Far;
    }

    protected GameObject GetHighestMaxHealth()
    {
        GameObject Highest = null;
        float mostHealth = 0.0f;

        foreach (Collider2D enemy in DetectEnemies())
        {
            EnemyBaseClass tempEnemyClass = enemy.GetComponent<EnemyBaseClass>();

            if (tempEnemyClass.GetMaxHealth() > mostHealth)
            {
                Highest = enemy.gameObject;
                mostHealth = tempEnemyClass.GetMaxHealth();
                continue;
            }
        }

        return Highest;
    }

    protected GameObject GetLowestMaxHealth()
    {
        GameObject Lowest = null;
        float leastHealth = Mathf.Infinity;

        foreach (Collider2D enemy in DetectEnemies())
        {

            EnemyBaseClass tempEnemyClass = enemy.GetComponent<EnemyBaseClass>();

            if (tempEnemyClass.GetMaxHealth() < leastHealth)
            {
                Lowest = enemy.gameObject;
                leastHealth = tempEnemyClass.GetMaxHealth();
                continue;
            }
        }

        return Lowest;
    }

    protected GameObject GetMaxCurrentHealth()
    {
        GameObject Highest = null;
        float currentHighest = -1.0f;

        foreach (Collider2D enemy in DetectEnemies())
        {

            EnemyBaseClass tempEnemyClass = enemy.GetComponent<EnemyBaseClass>();

            if (tempEnemyClass.GetCurrentHealth() > currentHighest)
            {
                Highest = enemy.gameObject;
                currentHighest = tempEnemyClass.GetCurrentHealth();
                continue;
            }
        }

        return Highest;
    }

    protected GameObject GetLowestCurrentHealth()
    {
        GameObject Lowest = null;
        float currentLowest = Mathf.Infinity;

        foreach (Collider2D enemy in DetectEnemies())
        {

            EnemyBaseClass tempEnemyClass = enemy.GetComponent<EnemyBaseClass>();

            if (tempEnemyClass.GetCurrentHealth() < currentLowest)
            {
                Lowest = enemy.gameObject;
                currentLowest = tempEnemyClass.GetCurrentHealth();
                continue;
            }
        }

        return Lowest;
    }

    protected bool IsTargetInRange(GameObject target)
    {
        if (!target)
            return false;

        if(DistanceToTarget(target) > TowerRange)
        {
            return false;
        }
        return true;
    }

    protected virtual void AITick() { }

    protected float DistanceToTarget(GameObject target)
    {
        float distance = (target.transform.position - transform.position).magnitude;

        return distance;
    }
}
