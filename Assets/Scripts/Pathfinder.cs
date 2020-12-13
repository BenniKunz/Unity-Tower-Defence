using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();


    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    // Start is called before the first frame update
    void Start()
    {

    }

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            //ColorStartEnd();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        endWaypoint.isPlaceable = false;
        Waypoint previous = endWaypoint.exploredFrom;

        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous.isPlaceable = false;
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        startWaypoint.isPlaceable = false; 
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();

            StopIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }

    private void StopIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            //print("Attention! Start = End");
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
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
        if (neighbour.isExplored == false && !(queue.Contains(neighbour)))
        {
            //neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    //private void ColorStartEnd()
    //{
    //    startWaypoint.SetTopColor(Color.green);
    //    endWaypoint.SetTopColor(Color.black);
    //}

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
