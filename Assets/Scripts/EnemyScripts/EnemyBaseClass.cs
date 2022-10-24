using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Rendering;
using UnityEngine;
/*-----------------------------------------
 * EnemyBaseClass.cs - Evan Coffey - 101267129
 * 
 * Stores base info about enemies, may be expanded to hold the ai
 * 
 * Version History -
 * 10/20/2022 - Created class and added base values like health
 * 10/21/2022 - added basic node based movements
 * 10/22/2022 - added the ability for enemies to take damage and display on the health bar
 * 10/23/2022 - Moving all health functions to the Health bar to reduce double code
 * 10/23/2022 - add some formatting to the variables and made a new one for when it reaches the exit. Reaching exit does damage
 * 
 * Latest Revision -
 * 10/23/2022
 * ----------------------------------------
 */
public class EnemyBaseClass : MonoBehaviour
{
    [SerializeField, ReadOnly(true)]
    private int CurrentTargetNode = -1;
    [SerializeField, ReadOnly(true)]
    private Vector3 TargetNodePosition;

    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float Deviation = 0.5f;

    [SerializeField]
    private int EscapeDamage = 1;

    [SerializeField]
    private HealthBar healthBar;

    private Rigidbody2D rb;

    protected void Start()
    {
        CurrentTargetNode = -1;
        rb = GetComponent<Rigidbody2D>();

        Invoke("GetNextNodePosition", 0.00001f);
    }

    private void GetNextNodePosition()
    {
        CurrentTargetNode++;

        if(CurrentTargetNode >= MapNodeControllerScript.instance.GetMaxNodes())
        {
            ReachExit();
            return;
        }
        TargetNodePosition = MapNodeControllerScript.instance.GetNodePosition(CurrentTargetNode);
    }

    protected void Update()
    {
        AITick();
    }

    protected void FixedUpdate()
    {
        AIMovementTick();
    }

    protected void AITick()
    {

    }
    protected void AIMovementTick()
    {
        Vector3 movementVector = TargetNodePosition - transform.position;
        movementVector.Normalize();

        Vector3 OrigionalPosition = transform.position;

        rb.MovePosition(OrigionalPosition + movementVector * speed * Time.deltaTime);

        if ((transform.position - TargetNodePosition).magnitude < Deviation)
        {
            GetNextNodePosition();
        }
    }

    public void TakeDamage(float value)
    {
        healthBar.TakeDamage(value);
        if(healthBar.GetIsDead())
        {
            Die();
        }
    }

    private void Die()
    {
        CreateDrop();
        Destroy(gameObject);
    }

    private void ReachExit() //this could be changed to use an object pool for the enemies
    {
        LevelHealthController.instance.LoseHealth(EscapeDamage);
        Destroy(gameObject);
    }

    public float GetMaxHealth()
    {
        return healthBar.GetMaxHealth();
    }

    public float GetCurrentHealth()
    {
        return healthBar.GetCurrentHealth();
    }

    private void CreateDrop()
    {
        GameObject drop = DropsManagerScript.instance.GetDrop(DropTypes.GoldBag);
        Vector3 OffsetDirection = (TargetNodePosition - transform.position).normalized;
        Vector3 OffsetDirectionPerp = new Vector3(OffsetDirection.y, OffsetDirection.x, 0.0f);

        float sign = 0;
        if (Random.Range(0, 2) == 0)
            sign = 1;
        else
            sign = -1;

        PickUpScript tempPickUp = drop.GetComponent<PickUpScript>();
        tempPickUp.SetTargtePosition(transform.position + OffsetDirectionPerp * Random.Range(1.0f, 2.0f) * sign + OffsetDirection * Random.Range(-0.5f, 0.5f));
        drop.transform.position = transform.position;
    }
}
