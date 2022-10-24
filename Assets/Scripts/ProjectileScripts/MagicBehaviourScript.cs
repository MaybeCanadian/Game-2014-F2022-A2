using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*-------------------------------------
 * MagicBehaviourScript.cs - Evan Coffey 101267129
 * 
 * Used to control the magic type projectile, it explodes.
 * 
 * Version History -
 * 10/24/2022 - created script
 * 
 * Latest Revision -
 * 10/23/2022
 * ------------------------------------
 */
public class MagicBehaviourScript : ArrowBehaviorScript
{
    [SerializeField]
    private LayerMask enemyLayers;
    [SerializeField]
    private float BlastRadius;

   protected void RemoveMagic()
    {
        ProjectileManager.instance.ReturnArrow(gameObject);
    }

    private void HitSomething(GameObject other)
    {
        Collider2D[] InRange =  Physics2D.OverlapCircleAll(transform.position, BlastRadius, enemyLayers);

        foreach(Collider2D enemy in InRange)
        {
            EnemyBaseClass enemyBase = enemy.GetComponent<EnemyBaseClass>();

            if(enemyBase)
            {
                enemyBase.TakeDamage(Damage);
            }
        }

        GameObject ExplosionEffect = EffectManager.instance.CreateEffect(EffectTypes.Explosion);
        ExplosionEffect.transform.position = transform.position;
        ExplosionEffect.transform.localScale = new Vector3(BlastRadius * 2, BlastRadius * 2, 1.0f);

        ProjectileManager.instance.ResturnMagic(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            this.HitSomething(collision.gameObject);
        }
    }
}
