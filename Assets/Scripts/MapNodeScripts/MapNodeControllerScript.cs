using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*-----------------------------------
 * MapNodeControllerScript.cs - Evan Coffey - 101267129
 * 
 * Keeps track of all the nodes as well as the order of them all, then enemies can use it to find the path
 * 
 * Version History -
 * 10/21/2022 - created script
 * 
 * Latest Revision -
 * 10/21/2022
 * ----------------------------------
 */
public class MapNodeControllerScript : MonoBehaviour
{
    public static MapNodeControllerScript instance;

    [SerializeField]
    private List<MapNodeScript> AllNodes;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void AddNode(MapNodeScript node)
    {
        AllNodes.Add(node);
    } 

    public Vector3 GetNodePosition(int NodeNumber)
    {
        foreach(MapNodeScript node in AllNodes)
        {
            if(node.GetNodeNumber() == NodeNumber)
            {
                return node.transform.position;
            }
        }

        return new Vector3(0.0f, 0.0f, 0.0f);
    }

    public int GetMaxNodes()
    {
        return AllNodes.Count;
    }
}
