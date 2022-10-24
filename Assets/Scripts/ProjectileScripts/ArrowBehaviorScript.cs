using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*-------------------------------------------
 * ArrowBehaviorScript.cs - Evan Coffey - 101267129
 * 
 * Controls how arrows move in the game.
 * 
 * Version History -
 * 10/22/2022 - created script
 * 10/22/2022 - adjusted the script to use a movespeed
 * 10/22/2022 - added more values for the arrow
 * 10/23/2022 - Adjusted the arrow to know if it should be removed to not damage extra enemies by accident
 * 10/24/2022 - made the attack function call the play sound effect function
 * 
 * Latest Revision -
 * 10/24/2022
 * ------------------------------------------
 */
public class ArrowBehaviorScript : MonoBehaviour
{
    [Header("Projectile Values")]
    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected float arrowSpeed = 40.0f;
    [SerializeField]
    protected float LifeSpan = 10.0f;
    [SerializeField]
    protected float Damage = 10.0f;
    [SerializeField]
    protected int Pierces = 0;

    private int PierceCount = 0;
    public bool IsRemoved = false;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("RemoveArrow", LifeSpan);
        PierceCount = 0;
    }

    public void SetUp()
    {
        IsRemoved = false;
        PierceCount = 0;
    }

    public void SetVelocity(Vector3 input)
    {
        rb.velocity = input * arrowSpeed;
    }

    public void SetSpeed(float input)
    {
        arrowSpeed = input;
    }

    public void SetDamage(float input)
    {
        Damage = input;
    }

    public void SetPierces(int value)
    {
        Pierces = value;
    }

    protected void RemoveArrow()
    {
        ProjectileManager.instance.ReturnArrow(gameObject);
    }

    private void HitSomething(GameObject other)
    {
        if (!IsRemoved)
        {
            other.GetComponent<EnemyBaseClass>().TakeDamage(Damage);

            if (PierceCount >= Pierces)
            {
                IsRemoved = true;
                RemoveArrow();
            }

            PierceCount++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            this.HitSomething(collision.gameObject);
        }
    }
}
