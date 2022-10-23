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
    [SerializeField]
    private GameObject JoystickParent;
    [SerializeField]
    private Image JoyStickBase;
    [SerializeField]
    private Image JoystickHead;
}
