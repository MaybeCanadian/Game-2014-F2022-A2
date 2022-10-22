using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SlimeScript : EnemyBaseClass
{
    [Range(0.01f, 200.0f)]
    public float attackSpeed = 1.0f;
    [ReadOnly(true), SerializeField]
    private bool AttackCoolDown;


    private void Start()
    {
        base.Start();
        AttackCoolDown = false;
    }

    private new void FixedUpdate()
    {
        SlimeAITick();
    }

    protected void SlimeAITick()
    {
        base.AIMovementTick();

        if (AttackCoolDown == false)
        {
            //Debug.Log("Slime attack");
            AttackCoolDown = true;
            Invoke("ResetCoolDown", 1.0f / attackSpeed);
        }
    }

    private void ResetCoolDown()
    {
        AttackCoolDown = false;
    }
}
