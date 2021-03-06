using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent (typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    // Start is called before the first frame update

    Waypoint waypoint;


    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        Vector2Int gridPos = waypoint.CalcGridPos() * gridSize;
        transform.position = new Vector3(gridPos.x, 0f, gridPos.y);
    }

    private void UpdateLabel()
    {
        Vector2Int gridPos = waypoint.CalcGridPos();

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = gridPos.x + "," + gridPos.y;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
