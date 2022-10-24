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

    protected override void Attack(GameObject enemy)
    {
        PlayAttackSound();

        GameObject TempMagic = ProjectileManager.instance.GetMagicShot();
        TempMagic.transform.position = transform.position;
        TempMagic.transform.right = enemy.transform.position - transform.position;
        ArrowBehaviorScript TempMagicBehavior = TempMagic.GetComponent<MagicBehaviourScript>();
        TempMagicBehavior.SetSpeed(ProjectileSpeed);
        TempMagicBehavior.SetVelocity((towerTarget.transform.position - transform.position).normalized);
        TempMagicBehavior.SetDamage(Damage);
        TempMagicBehavior.SetPierces(0);
        TempMagicBehavior.SetUp();
    }
}
