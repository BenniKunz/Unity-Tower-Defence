using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 4;
    [SerializeField] Tower towerPrefab;

    // Start is called before the first frame update
    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerLimit > 0)
        {
            InstantiateNewTower(baseWaypoint);
            towerLimit--;
        }
        else
        {

            print("Tower limit reached");
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Vector3 position = new Vector3(baseWaypoint.transform.position.x, 5f, baseWaypoint.transform.position.z);
        Instantiate(towerPrefab, position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
    }
}
