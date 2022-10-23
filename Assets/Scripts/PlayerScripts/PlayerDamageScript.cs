using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
/*--------------------------------
 * PlayerDamageScript.cs - Evan Coffey - 101267129
 * 
 * Lets the player take damage from enemies, if they run out of health the player is unable to move for a bit
 * 
 * Version History -
 * 10/23/2022 - created script
 * 
 * Latest Revision -
 * 10/23/2022
 * -------------------------------
 */
public class PlayerDamageScript : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBar;

    [SerializeField, Tooltip("Health regained per seccond")]
    private float RegenSpeed = 1.0f;

    public void TakeDamage(float value)
    {
        healthBar.TakeDamage(value);
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            TakeDamage(10.0f);
        }
    }
}
