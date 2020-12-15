using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 4;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform parent;
    Queue<Tower> towers = new Queue<Tower>();

    // Start is called before the first frame update
    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);  
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }
    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Vector3 position = new Vector3(baseWaypoint.transform.position.x, 5f, baseWaypoint.transform.position.z);
        Tower tower = Instantiate(towerPrefab, position, Quaternion.identity);
        tower.transform.parent = parent;

        tower.baseTowerWaypoint = baseWaypoint;

        baseWaypoint.isPlaceable = false;

        towers.Enqueue(tower);
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        
        Tower tower = towers.Dequeue();
        tower.baseTowerWaypoint.isPlaceable = true;
        Vector3 position = new Vector3(baseWaypoint.transform.position.x, 5f, baseWaypoint.transform.position.z);
        tower.transform.position = position;
        baseWaypoint.isPlaceable = false;
        tower.baseTowerWaypoint = baseWaypoint;
        towers.Enqueue(tower);

    }

}
