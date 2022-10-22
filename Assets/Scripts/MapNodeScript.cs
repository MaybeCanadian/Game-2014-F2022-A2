using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*-------------------------------------------------
 * MapNodeScript.cs - Evan Coffey - 101267129
 * 
 * Adds itself to the MapNodeManager for the level
 * Used for enemy Pathfinding
 * 
 * Version History -
 * 10/21/2022 - created script
 * 10/21/2022 - added code that adds itself to the nodecontrollerscript
 * 
 * Latest Revision -
 * 10/21/2022
 * ------------------------------------------------
 */
public class MapNodeScript : MonoBehaviour
{
    [Tooltip("Order in path"), SerializeField]
    private int NodeNumber;

    private void Start()
    {
        MapNodeControllerScript.instance.AddNode(this);
    }

    public int GetNodeNumber()
    {
        return NodeNumber;
    }

    
}
