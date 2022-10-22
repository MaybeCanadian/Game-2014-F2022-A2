using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/*--------------------------------------------
 * ProjectileFactory.cs - Evan Coffey - 101267129
 * 
 * Makes the projectiles for the towers to shoot
 * 
 * Version History -
 * 10/22/2022 - created script
 * 
 * Latest Revision -
 * 10/22/2022
 *--------------------------------------------
 */

[System.Serializable]
public enum ProjectileTypes
{
    BasicArrow
}

public class ProjectileFactory : MonoBehaviour
{
    static public ProjectileFactory instance;

    List<GameObject> ProjectilePrefabs;

    public Transform ProjectileParent;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        ProjectilePrefabs = new List<GameObject>();

        //basic arrow
        ProjectilePrefabs.Add(Resources.Load<GameObject>("Prefabs/Projectiles/BasicArrow"));
    }

    public GameObject CreateProjectile(ProjectileTypes type)
    {
        GameObject TempProjectile = Instantiate(ProjectilePrefabs[((int)type)], ProjectileParent);
        return TempProjectile;
    } 
}
