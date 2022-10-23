using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*--------------------------------------------
 * PlayerMobileJoystickScript.cs - Evan Coffey - 101267129
 * 
 * Shows and controls the joystick to help player know how they are moving
 * 
 * Version History -
 * 10/23/2022 - created script
 * 
 * Latest Revision -
 * 10/23/2022
 * -------------------------------------------
 */
public class PlayerMobileJoystickScript : MonoBehaviour
{
    [Header("Joystick References")]
    [SerializeField]
    private GameObject JoystickParent;
    [SerializeField]
    private Image JoyStickBase;
    [SerializeField]
    private Image JoystickHead;
    private PlayerMovementController playerMove;
    [Header("Joystick Variables")]
    [SerializeField]
    private float OuterEdgeDistance = 20.0f;

    private void Start()
    {
        playerMove = FindObjectOfType<PlayerMovementController>();

        JoystickParent.SetActive(false);
    }

    private void Update()
    {
        if(playerMove.GetIsTouching())
        {
            JoystickParent.SetActive(true);
            DetermineJoystickPositions();
        }
        else
        {
            JoystickParent.SetActive(false);
        }
    }

    private void DetermineJoystickPositions()
    {
        JoyStickBase.transform.position = playerMove.GetTouchStartPosition();
        Vector3 playerMoveVector = playerMove.GetTouchMovementVector();
        JoystickHead.transform.position = JoyStickBase.transform.position + playerMoveVector * OuterEdgeDistance * playerMove.GetTouchScale();
    }
}
