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
 *  -10/23/2022 - added functions to help the joystick work
 *  -10/23/2022 - added a deadzone for the mobile controls
 *  -10/23/2022 - changed enimations to proritize the bigger greater absolute value
 * 
 * Date Last Modified
 * - 10/23/2022
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

    [Header("Mobile Input touch values")]
    [SerializeField, ReadOnly(true)]
    private bool IsTouching = false;
    private Vector2 TouchStart;
    private Vector2 TouchMoveVector;
    [SerializeField, ReadOnly(true)]
    private float TouchSpeedScale = 0.0f;
    [SerializeField]
    private float MaxSpeedOuter = 100.0f;
    private float currentMoveSpeed = 0.0f;
    [SerializeField]
    private float DeadZonePercent = 0.01f;


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

        currentMoveSpeed = PlayerMoveSpeed;
        MovePlayer(GetMovementInputKeyBoard());
    }

    private void MovePlayer(Vector3 moveTarget)
    {
        Vector3 origionalPosition = transform.position;

        Vector3 moveToPosition = origionalPosition + moveTarget.normalized * currentMoveSpeed * Time.fixedDeltaTime;

        moveToPosition = new Vector3(Mathf.Clamp(moveToPosition.x, screenBounds.HorizontalBounds.Min, screenBounds.HorizontalBounds.Max),
            Mathf.Clamp(moveToPosition.y, screenBounds.VerticalBounds.Min, screenBounds.VerticalBounds.Max), moveToPosition.z);

        rb.MovePosition(moveToPosition);
    }

    private void TouchMove()
    {
        MovePlayer(GetMovementInputMobile());
    }

    private Vector2 GetMovementInputMobile()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (IsTouching == false)
            {
                TouchStart = touch.position;
                IsTouching = true;
                TouchSpeedScale = 0.0f;
                currentMoveSpeed = PlayerMoveSpeed * TouchSpeedScale;
            }
            else
            {
                TouchMoveVector = (touch.position - TouchStart).normalized;
                TouchSpeedScale = (touch.position - TouchStart).magnitude / MaxSpeedOuter;

                if(TouchSpeedScale < DeadZonePercent)
                {
                    TouchMoveVector = new Vector2(0, 0);
                    TouchSpeedScale = 0.0f;
                }

                TouchSpeedScale = Mathf.Min(TouchSpeedScale, 1.0f);
                currentMoveSpeed = PlayerMoveSpeed * TouchSpeedScale;
                return TouchMoveVector;
            }

        }
        else
        {
            IsTouching = false;
            TouchSpeedScale = 0.0f;
            currentMoveSpeed = PlayerMoveSpeed * TouchSpeedScale;
        }

        return new Vector2(0, 0);
    }

    private Vector2 GetMovementInputKeyBoard()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Debug.Log(moveInput);
        return moveInput;
    }

    private void DoAnimations(Vector2 moveInput)
    {
        MovementDirections moveDirection = MovementDirections.NONE;

        if (moveInput.x < 0)
        {
            moveDirection = MovementDirections.LEFT;
        }
        else if (moveInput.x > 0)
        {
            moveDirection = MovementDirections.RIGHT;
        }
        if (Mathf.Abs(moveInput.x) <= Mathf.Abs(moveInput.y))
        {
            if (moveInput.y < 0)
                moveDirection = MovementDirections.DOWN;
            else if (moveInput.y > 0)
                moveDirection = MovementDirections.UP;
        }

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
    
    public Vector2 GetTouchStartPosition()
    {
        return TouchStart;
    }

    public bool GetIsTouching()
    {
        return IsTouching;
    }

    public Vector2 GetTouchMovementVector()
    {
        return TouchMoveVector;
    }

    public float GetTouchScale()
    {
        return TouchSpeedScale;
    }
}
