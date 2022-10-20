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
public class TowerBaseClass : MonoBehaviour
{
    [Header("Tower Statistics")]
    public float TowerHealth;
    public float TowerRange;
    public Collider2D[] DetectEnemies()
    {
        Collider2D[] allEnemies = Physics2D.OverlapCircleAll(transform.position, TowerRange);

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

            //if ( > mostHealth)
            //{
            //    Highest = enemy.gameObject;
            //    mostHealth = (transform.position - enemy.transform.position).magnitude;
            //    continue;
            //}
        }

        return Highest;
    }

    public GameObject GetLowestMaxHealth()
    {
        GameObject Lowest = null;
        float leastHealth = Mathf.Infinity;

        foreach (Collider2D enemy in DetectEnemies())
        {

            //if ((transform.position - enemy.transform.position).magnitude > mostHealth)
            //{
            //    Highest = enemy.gameObject;
            //    mostHealth = (transform.position - enemy.transform.position).magnitude;
            //    continue;
            //}
        }

        return Lowest;
    }
}
