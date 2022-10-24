using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*----------------------------------
 * EffectBehaviour.cs - Evan Coffey - 101267129
 * 
 * Controls how effects works, for now plays sounds and removes it after a time
 * if I switched to a factory style it could instead resturn
 * 
 * Version History -
 * 10/24/2022 - created script
 * 10/24/2022 - added sound effects
 * 
 * Latest Revision -
 * 10/24/2022
 * ---------------------------------
 */
public class EffectBehaviour : MonoBehaviour
{
    [SerializeField]
    private float LifeSpan = 1.0f;

    private void Start()
    {
        Invoke("Remove", LifeSpan);

    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
