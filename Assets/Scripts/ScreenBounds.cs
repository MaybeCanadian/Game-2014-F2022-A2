using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*-------------------------------------------
 * ScreenBounds.cs - Evan Coffey - 101267129
 * 
 * ScreenBounds and Boundry structs
 * 
 * Version History -
 * 10/20/2022 - Created Structs
 * 
 * Latest Revision -
 * 10/20/2022
 * ------------------------------------------
 */

[System.Serializable]
public struct ScreenBounds
{
    public Boundry HorizontalBounds;
    public Boundry VerticalBounds;
}

[System.Serializable]
public struct Boundry
{
    public float Min;
    public float Max;
}
