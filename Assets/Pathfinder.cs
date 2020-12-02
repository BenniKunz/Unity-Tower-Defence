using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    
    [SerializeField] Waypoint StartWaypoint, EndWaypoint;


    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartEnd();
    }

    private void ColorStartEnd()
    {
        StartWaypoint.SetTopColor(Color.green);
        EndWaypoint.SetTopColor(Color.black);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if (!(grid.ContainsKey(waypoint.CalcGridPos())))
            {
                grid.Add(waypoint.CalcGridPos(), waypoint);   
            }
            else
            {
                Debug.LogWarning("Overlapping block:" + waypoint.name);
            }
        }
    }

}
