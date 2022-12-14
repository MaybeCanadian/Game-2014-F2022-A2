using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
/*---------------------------------------
 * PickUpScript.cs - Evan Coffey - 101267129
 * 
 * Allows the player to pickUp objects like XP and coins.
 * 
 * Version History -
 * 10/22/2022 - created script
 * 10/22/2022 - added function to remove the pickUp
 * 10/24/2022 - added sound effects for pickUp
 * 
 * Latest Revision -
 * 10/24/2022
 * --------------------------------------
 */
public class PickUpScript : MonoBehaviour
{

    [SerializeField, ReadOnly(true)]
    private DropTypes dropType = DropTypes.GoldBag;
    [SerializeField, ReadOnly(true)]
    public float PickUpValue = 1.0f;
    Vector3 TargetPosition = new Vector3(0, 0, 0);
    public float MoveSpeed = 2.0f;

    private AudioSource audSRC;

    private void Start()
    {
        audSRC = GetComponent<AudioSource>();
        StartCoroutine("MoveToTargerPosition");
    }

    private IEnumerator MoveToTargerPosition()
    {
        while((transform.position - TargetPosition).magnitude > 0.1)
        {
            Vector3 moveDirection = TargetPosition - transform.position;
            moveDirection.Normalize();
            transform.position = transform.position + moveDirection * MoveSpeed * Time.deltaTime;

            yield return null;
        }

        yield break;
    }

    public DropTypes GetDropType()
    {
        return dropType;
    }

    public float GetValue()
    {
        return PickUpValue;
    }

    public void SetUpDrop(DropTypes type, float value)
    {
        dropType = type;
        PickUpValue = value;
    }

    public void PickUpPickUp()
    {
        StopAllCoroutines();
        switch(dropType)
        {
            case DropTypes.GoldBag:
                CurrencyManagerScript.instance.AddGold(((int)PickUpValue));
                break;
        }
        audSRC.Play();
        DropsManagerScript.instance.ReturnDrop(gameObject);
    }

    public void SetTargtePosition(Vector3 Target)
    {
        TargetPosition = Target;
    }
}
