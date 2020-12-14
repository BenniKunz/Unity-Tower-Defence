using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    Waypoint waypoint;
    int waypointPosition = 0;
    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        transform.position = path[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        waypoint = path[waypointPosition];


        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, step);
        float distance = Vector3.Distance(transform.position, waypoint.transform.position);

        if(distance < 0.001f)
        {
            if(waypointPosition < path.Count -1)
            waypointPosition++;
        }
    }
}
