using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
/*----------------------------------------
 * ChestBehaviorScript.cs - Evan Coffey - 101267129
 * 
 * Controls the behvior of chests like opening then dropping items
 * 
 * Version History -
 * 10/23/2022 - created script and added functionality
 * 
 * Latest Revision -
 * 10/23/2022
 * ---------------------------------------
 */
public class ChestBehaviorScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField, ReadOnly(true)]
    private bool Opening = false;
    [SerializeField]
    private int MaxGoldBags = 10;
    [SerializeField]
    private int MinGoldBags = 1;
    [SerializeField]
    private float RemoveTime = 5.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!Opening)
            {
                animator.SetTrigger("OpenChest");
                Opening = true;
                DropGold();
                Invoke("RemoveChest", RemoveTime);
            }
        }
    }

    private void DropGold()
    {
        int numGoldBags = Random.Range(MinGoldBags, MaxGoldBags);
        Debug.Log(numGoldBags);
        for(int i = 0; i < numGoldBags; i++)
        {
            GameObject tempDrop = DropsManagerScript.instance.GetDrop(DropTypes.GoldBag);
            tempDrop.transform.position = transform.position;

            PickUpScript tempPickUp = tempDrop.GetComponent<PickUpScript>();

            float Offset = Random.Range(0.2f, 1.0f);

            float OffsetAngle = Random.Range(0, Mathf.PI);

            Vector3 target = new Vector3(Offset * Mathf.Sign(OffsetAngle), Offset * Mathf.Cos(OffsetAngle), 0.0f) + transform.position;

            tempPickUp.SetTargtePosition(target);
        }
    }

    private void RemoveChest()
    {
        Destroy(gameObject);
    }
}
