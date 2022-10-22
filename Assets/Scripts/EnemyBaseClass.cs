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
 * 
 * Latest Revision -
 * 10/21/2022
 * ----------------------------------------
 */
public class EnemyBaseClass : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
    public int CurrentTargetNode = -1;
    public Vector3 TargetNodePosition;

    public float speed = 10.0f;
    public float Deviation = 0.5f;

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
}
