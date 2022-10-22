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
 * 
 * Latest Revision -
 * 10/22/2022
 * ------------------------------------------
 */
public class ArrowBehaviorScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float arrowSpeed = 40.0f;
    public float LifeSpan = 10.0f;
    public float ArrowDamage = 10.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("RemoveArrow", LifeSpan);
    }

    public void SetVelocity(Vector3 input)
    {
        rb.velocity = input * arrowSpeed;
    }

    public void SetSpeed(float input)
    {
        arrowSpeed = input;
    }

    private void RemoveArrow()
    {
        ProjectileManager.instance.ReturnArrow(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyBaseClass>().TakeDamage(ArrowDamage);
            RemoveArrow();
        }
    }
}
