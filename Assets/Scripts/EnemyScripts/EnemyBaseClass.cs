using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
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
 * 
 * Latest Revision -
 * 10/23/2022
 * ----------------------------------------
 */
public class EnemyBaseClass : MonoBehaviour
{
    public int CurrentTargetNode = -1;
    public Vector3 TargetNodePosition;

    public float speed = 10.0f;
    public float Deviation = 0.5f;

    public HealthBar healthBar;

    Rigidbody2D rb;

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
            Debug.Log("Ouch");
            Destroy(gameObject);
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
