using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*-------------------------------------------
 * MageTowerBaseClass.cs - Evan Coffey - 101267129
 * 
 * Controls how the Mage towers work, the attacks are a different type than ranged
 * 
 * Version History -
 * 10/23/2022 - script created
 * 
 * Latest Revision -
 * 10/23/2022
 * ------------------------------------------
 */

public class MageTowerBaseClass : TowerBaseClass
{
    [SerializeField]
    private float ProjectileSpeed = 30.0f;
    [SerializeField]
    private float BlastRadius = 1.0f;

    private void Update()
    {
        AITick();
    }
    protected override void AITick()
    {
        base.AITick();
    }

    protected override void Attack(GameObject target)
    {
        //Debug.Log("attack Mage");
    }
}
