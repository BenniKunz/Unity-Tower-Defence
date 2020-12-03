using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true;

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartEnd();
        Pathfind();
        //ExploreNeighbours();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            Waypoint searchCenter = queue.Dequeue();
            print("Searching from" + (searchCenter));
            StopIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
            searchCenter.isExplored = true;
        }
    }

    private void StopIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Attention! Start = End");
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint searchCenter)
    {
        if (!isRunning)
        {
            return;
        }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = searchCenter.CalcGridPos() + direction;

            if (grid.ContainsKey(explorationCoordinates))
            {
                QueueNewNeighbours(explorationCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored == false)
        {
            neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            print("Queueing" + neighbour);
        }
    }

    private void ColorStartEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.black);
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
