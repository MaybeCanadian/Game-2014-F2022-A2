using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
/*-----------------------------------
 * ProjectileManager.cs - Evan Coffey - 101267129
 * 
 * Keeps Track of the projectiles and gives them to towers that need them
 * 
 * Version History -
 * 10/22/2022 - script created
 * 
 * Latest Revision -
 * 10/22/2022
 * ----------------------------------
 */
public class ProjectileManager : MonoBehaviour
{
    [SerializeField, ReadOnly(true)]
    private Queue<GameObject> BasicArrowPool;
    [SerializeField, ReadOnly(true)]
    private float activeArrows = 0;
    [SerializeField]
    private float StartingArrows = 50;
    [SerializeField, ReadOnly(true)]
    private float remainingArrows = 0;

    public static ProjectileManager instance;

    private void Awake()
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

    private void Start()
    {
        SetUpProjectilePool();
    }

    private void SetUpProjectilePool()
    {
        BasicArrowPool = new Queue<GameObject>();

        for (int i = 0; i < StartingArrows; i++)
        {
            AddArrow();
        }

        remainingArrows = BasicArrowPool.Count;
    }

    private void AddArrow()
    {
        GameObject TempArrow = ProjectileFactory.instance.CreateProjectile(ProjectileTypes.BasicArrow);
        TempArrow.SetActive(false);

        BasicArrowPool.Enqueue(TempArrow);
    }

    public GameObject GetBasicArrow()
    {
        if(BasicArrowPool.Count == 0)
        {
            AddArrow();
        }

        GameObject TempArrow = BasicArrowPool.Dequeue();
        TempArrow.SetActive(true);
        activeArrows++;
        remainingArrows = BasicArrowPool.Count;

        return TempArrow;
    }

    public void ReturnArrow(GameObject arrow)
    {
        arrow.SetActive(false);
        BasicArrowPool.Enqueue(arrow);
        activeArrows--;
        remainingArrows = BasicArrowPool.Count;
    }
}
