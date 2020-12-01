using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindPath());
    }

    IEnumerator FindPath()
    {
        print("Starting patrol");
        foreach(Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print($"Visiting block {waypoint.name}");
        }
        print("Ending patrol");
        yield return new WaitForSeconds(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
