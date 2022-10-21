using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedTowerBaseClass : TowerBaseClass
{
    private void Update()
    {
        AITick();
    }

    public override void AITick()
    {

        GameObject enemy = this.GetClosestEnemyInRange();

        if (enemy)
            Debug.Log("found someone");
        base.AITick();
    }
}
