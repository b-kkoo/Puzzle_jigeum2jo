using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkable : MonoBehaviour
{
    public float walkPointOffset = 0.5f;
    public float stairOffset = 0.4f;

    public bool isStair = false;

    public List<WalkPath> possiblePaths = new List<WalkPath>();

    public Vector3 GetWalkPoint()
    {
        float stair = isStair ? stairOffset : 0;
        return transform.position + transform.up * walkPointOffset - transform.up * stair;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        float stair = isStair ? .4f : 0;
        Gizmos.DrawSphere(GetWalkPoint(), .1f);

        if (possiblePaths == null)
            return;

        foreach (WalkPath path in possiblePaths)
        {
            if (path.target == null)
            {
                return;
            }
            Gizmos.color = path.active ? Color.blue : Color.clear;
            Gizmos.DrawLine(GetWalkPoint(), path.target.GetComponent<Walkable>().GetWalkPoint());
        }
    }
}

[System.Serializable]
public class WalkPath
{
    public Transform target;
    public bool active = true;
}