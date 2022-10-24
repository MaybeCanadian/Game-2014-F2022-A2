using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*-------------------------------------------
 * PlayerPickUpScript.cs - Evan Coffey - 101267129
 * 
 * Allows the player to pickUp drops and prooperly update the money and xp managers
 * 
 * Version History -
 * 10/22/2022 - script created
 * 
 * Latest Revision -
 * 10/22/2022
 * ------------------------------------------
 */
public class PlayerPickUpScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PickUps")
        {
            Debug.Log("Picked Up something");

            PickUpScript tempPickUp = collision.gameObject.GetComponent<PickUpScript>();

            if(tempPickUp)
            {
                tempPickUp.PickUpPickUp();
            }
        }
    }
}
