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
 * 
 * Latest Revision -
 * 10/21/2022
 * -----------------------------
 */


public class RangedTowerBaseClass : TowerBaseClass
{
    private void Update()
    {
        AITick();
    }

    protected override void AITick()
    {
        base.AITick();

        if (!TowerHasTarget)
        {
            towerTarget = this.GetClosestEnemyInRange();

            if (!towerTarget)
            {
                return;
            }

            TowerHasTarget = true;
        }
        else
        {
            if (!IsTargetInRange(towerTarget))
            {
                return;
            }
        }

        if (AttackCoolDown == false)
        {
            AttackCoolDown = true;
            Invoke("ResetAttackCoolDown", 1.0f / AttackSpeed);
            Attack(towerTarget);
        }
    }

    protected void Attack(GameObject enemy)
    {
        Debug.Log("attack " + DistanceToTarget(enemy));
    }

}
