using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint StartWaypoint, EndWaypoint;

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartEnd();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = StartWaypoint.CalcGridPos() + direction;

            if (grid.ContainsKey(explorationCoordinates))
            {
                print("Explore:" + explorationCoordinates);
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
        }
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
