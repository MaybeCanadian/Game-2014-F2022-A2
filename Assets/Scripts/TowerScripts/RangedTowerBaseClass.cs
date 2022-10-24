using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*------------------------------
 * RangedTowerBaseClass.cs - Evan Coffey - 101267129
 * 
 * Sub class of the base tower that handles all towers of the ranged type, not melee, baricade or magic
 * 
 * Version History -
 * 10/20/2022 - Created File and set up basic AI tick using base tower functions
 * 10/21/2022 - Added in some basic atack patterns, for now will output a debug message
 * 10/22/2022 - Added variables to help control the type of arrow the tower shoots
 * 10/23/2022 - adjusted the attack function to call the new setup function of the arrow
 * 
 * Latest Revision -
 * 10/23/2022
 * -----------------------------
 */
public class RangedTowerBaseClass : TowerBaseClass
{
    [SerializeField]
    private float ArrowSpeed = 60.0f;
    [SerializeField]
    private int ArrowPierce = 0;

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
        GameObject TempArrow = ProjectileManager.instance.GetBasicArrow();
        TempArrow.transform.position = transform.position;
        TempArrow.transform.right = enemy.transform.position - transform.position;
        ArrowBehaviorScript TempArrowBehavior = TempArrow.GetComponent<ArrowBehaviorScript>();
        TempArrowBehavior.SetSpeed(ArrowSpeed);
        TempArrowBehavior.SetVelocity((towerTarget.transform.position - transform.position).normalized);
        TempArrowBehavior.SetDamage(Damage);
        TempArrowBehavior.SetPierces(ArrowPierce);
        TempArrowBehavior.SetUp();
    }

}
