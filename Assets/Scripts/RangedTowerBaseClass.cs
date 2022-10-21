using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedTowerBaseClass : TowerBaseClass
{

    private void Start()
    {
        TowerManagerScript.instance.AddTower(this as TowerBaseClass);
    }
    public override void AITick()
    {

        GameObject enemy = this.GetClosestEnemyInRange();

        if (enemy)
            Debug.Log("found someone");
        base.AITick();
    }
}
