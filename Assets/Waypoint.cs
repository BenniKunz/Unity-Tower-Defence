﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;
    public bool isExplored = false;
   

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2Int CalcGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
