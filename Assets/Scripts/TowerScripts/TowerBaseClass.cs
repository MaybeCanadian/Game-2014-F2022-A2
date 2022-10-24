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
 * 10/24/2022 - added sound effects for attacks
 * 10/24/2022 - add interaction with stat tracker on start
 * 
 * Latest Revision -
 * 10/24/2022
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
    protected float TowerHealth = 100.0f;
    [Header("How far the Tower Detects Enemies"), SerializeField]
    protected float TowerRange = 1.0f;
    [Range(0.01f, 200.0f), Tooltip("Attacks per seccond"), SerializeField]
    protected float AttackSpeed = 1.0f;
    [Tooltip("If the Tower Can Attack"), ReadOnly(true), SerializeField]
    protected bool AttackCoolDown = false;
    [Tooltip("If Tower has a target"), ReadOnly(true), SerializeField]
    protected bool TowerHasTarget = false;

    [Header("Sprite Direction")]
    [SerializeField, Tooltip("Add in order Left, Up, Right, Down")]
    private Sprite[] directionSprites = new Sprite[4];
    [SerializeField]
    private SpriteRenderer sr;

    [Header("Enemy Layer")]
    public LayerMask EnemyLayerMask;

    protected GameObject towerTarget;

    [Header("Targeting Mode")]
    [SerializeField]
    protected TargetingMode currentMode = TargetingMode.CLOSE;
    [SerializeField]
    protected float LookAngle;

    [Header("Tower Damage")]
    [SerializeField, ReadOnly(true)]
    protected float Damage = 10.0f;

    [Header("Sound effects")]
    [SerializeField]
    private AudioSource audSrc;

    private void Start()
    {
        AttackCoolDown = false;
        TowerHasTarget = false;
        towerTarget = null;
        sr = GetComponent<SpriteRenderer>();
        audSrc = GetComponent<AudioSource>();
        StatTracker.instance.AddTowerMade(1);
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

    protected virtual void AITick()
    {
        switch(currentMode)
        {
            case TargetingMode.CLOSE:
                towerTarget = this.GetClosestEnemyInRange();
                break;
            case TargetingMode.FAR:
                towerTarget = this.GetFarthustEnemy();
                break;
            case TargetingMode.MOSTMAXHEALTH:
                towerTarget = this.GetHighestMaxHealth();
                break;
            case TargetingMode.LEASTMAXHEALTH:
                towerTarget = this.GetLowestMaxHealth();
                break;
            case TargetingMode.MOSTCURRENTHEALTH:
                towerTarget = this.GetMaxCurrentHealth();
                break;
            case TargetingMode.LEASTCURRENTHEALTH:
                towerTarget = this.GetLowestCurrentHealth();
                break;
        }

        if (!towerTarget)
        {
            return;
        }

        if (AttackCoolDown == false)
        {
            //FaceTarget(towerTarget); //doesn't want to work
            AttackCoolDown = true;
            Invoke("ResetAttackCoolDown", 1.0f / AttackSpeed);
            Attack(towerTarget);
        }
    }
    protected void FaceTarget(GameObject target)
    {
        Vector3 LookDirection = transform.position - target.transform.position;
        LookDirection.Normalize();
        if (LookDirection.x != 0) {
            LookAngle = Mathf.Tan(LookDirection.y / LookDirection.x);
        }
        else
        {
            LookAngle = 0.0f;
        }

        LookAngle = LookAngle * Mathf.Rad2Deg;

        if(LookAngle < 90)
        {
            sr.sprite = directionSprites[0];
            return;
        }
        
        if(LookAngle < 180)
        {
            sr.sprite = directionSprites[1];
            return;
        }

        if(LookAngle < 270)
        {
            sr.sprite = directionSprites[2];
            return;
        }

        sr.sprite = directionSprites[3];


    }

    protected void PlayAttackSound()
    {
        if(audSrc)
            audSrc.Play();
    }

    protected virtual void Attack(GameObject target) { }

    protected float DistanceToTarget(GameObject target)
    {
        float distance = (target.transform.position - transform.position).magnitude;

        return distance;
    }
}
