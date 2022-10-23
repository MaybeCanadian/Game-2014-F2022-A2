using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

/*-------------------------------------------------------------------------------------------------------------------------------------
 * PlayerMovementController.cs -- script used to control the players movement by various control schemes
 * 
 * By Evan Coffey -- 101267129
 * 
 * Revision History 
 * - 10/16/2022 - file created
 * - 10/16/2022 - Based variables and references set up
 * - 10/19/2022 - Set up distinction between mobile and computer inputs
 * - 10/20/2022 - removed the debug output
 *  -10/23/2022 - Added animation controls
 * 
 * Date Last Modified
 * - 10/20/2022
 * 
 * ------------------------------------------------------------------------------------------------------------------------------------
 */

public enum MovementDirections
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    NONE
}

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

    [Header("Animations")]
    public Animator anims;
    [SerializeField, ReadOnly(true)]
    private MovementDirections lastDirection = MovementDirections.NONE;

    private Touch currentMoveTouch;


    // Start is called before the first frame update
    void Start()
    {
        if(ForceMobileInput)
        {
            UsingMobileInput = true;
        }
    }

    private void Update()
    {
        Vector2 moveInput;

        if(UsingMobileInput)
        {
            moveInput = GetMovementInputMobile();
        }
        else
        {
            moveInput = GetMovementInputKeyBoard();
        }

        DoAnimations(moveInput);
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
        //Debug.Log(MoveInput);
        Vector3 origionalPosition = transform.position;

        Vector3 moveToPosition = origionalPosition + MoveInput.normalized * PlayerMoveSpeed * Time.fixedDeltaTime;

        moveToPosition = new Vector3(Mathf.Clamp(moveToPosition.x, screenBounds.HorizontalBounds.Min, screenBounds.HorizontalBounds.Max),
            Mathf.Clamp(moveToPosition.y, screenBounds.VerticalBounds.Min, screenBounds.VerticalBounds.Max), moveToPosition.z);

        rb.MovePosition(moveToPosition);
    }

    private void TouchMove() 
    { 
        
    }

    private Vector2 GetMovementInputMobile()
    {
        Vector2 moveInput = new Vector2(0, 0);

        return moveInput;
    }

    private Vector2 GetMovementInputKeyBoard()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Debug.Log(moveInput);
        return moveInput;
    }

    private void DoAnimations(Vector2 moveInput)
    {
        MovementDirections moveDirection = MovementDirections.NONE;

        if (moveInput.x < 0)
            moveDirection = MovementDirections.LEFT;
        else if (moveInput.x > 0)
            moveDirection = MovementDirections.RIGHT;

        if (moveInput.y < 0)
            moveDirection = MovementDirections.DOWN;
        else if (moveInput.y > 0)
            moveDirection = MovementDirections.UP;


        if (lastDirection != moveDirection)
        {
            lastDirection = moveDirection;
            ResetBools();
            SetAnimBool(moveDirection);
        }
    }

    private void ResetBools()
    {
        anims.SetBool("WalkingUp", false);
        anims.SetBool("WalkingDown", false);
        anims.SetBool("WalkingLeft", false);
        anims.SetBool("WalkingRight", false);
    }

    private void SetAnimBool(MovementDirections direction)
    {
        switch (direction)
        {
            case MovementDirections.UP:
                anims.SetBool("WalkingUp", true);
                break;
            case MovementDirections.DOWN:
                anims.SetBool("WalkingDown", true);
                break;
            case MovementDirections.LEFT:
                anims.SetBool("WalkingLeft", true);
                break;
            case MovementDirections.RIGHT:
                anims.SetBool("WalkingRight", true);
                break;
            case MovementDirections.NONE:
                //nothing
                break;
        }
    }
    
}
