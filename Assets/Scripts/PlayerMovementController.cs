using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-------------------------------------------------------------------------------------------------------------------------------------
 * PlayerMovementController.cs -- script used to control the players movement by various control schemes
 * 
 * By Evan Coffey -- 101267129
 * 
 * Revision History 
 * - 10/16/2022 - file created
 * - 10/16/2022 - Based variables and references set up
 * - 10/19/2022 - Set up distinction between mobile and computer inputs
 * 
 * 
 * Date Last Modified
 * - 10/19/2022
 * 
 * ------------------------------------------------------------------------------------------------------------------------------------
 */

public class PlayerMovementController : MonoBehaviour
{
    [Header("Player Movement References")]
    public Rigidbody2D rb; //rigid body of the player to allow for physics based movements, ie MoveTo

    [Header("Player Movement Variables")]
    public float PlayerMoveSpeed = 10.0f;

    [Header("Debug Overrides")]
    public bool ForceMobileInput = false;

    private bool UsingMobileInput = false;

    [Header("Movement Bounds")]
    public ScreenBounds screenBounds;

    private Touch currentMoveTouch;


    // Start is called before the first frame update
    void Start()
    {
        if(ForceMobileInput)
        {
            UsingMobileInput = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(UsingMobileInput)
        {
            TouchMove();
        }
        else
        {
            KeyboardMove();
        }
    }

    private void KeyboardMove()
    {
        Vector3 MoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        Debug.Log(MoveInput);
        Vector3 origionalPosition = transform.position;

        Vector3 moveToPosition = origionalPosition + MoveInput.normalized * PlayerMoveSpeed * Time.fixedDeltaTime;

        moveToPosition = new Vector3(Mathf.Clamp(moveToPosition.x, screenBounds.HorizontalBounds.Min, screenBounds.HorizontalBounds.Max),
            Mathf.Clamp(moveToPosition.y, screenBounds.VerticalBounds.Min, screenBounds.VerticalBounds.Max), moveToPosition.z);

        rb.MovePosition(moveToPosition);
    }

    private void TouchMove() 
    { 
        
    }
}
