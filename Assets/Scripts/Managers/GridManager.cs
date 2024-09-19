using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int xSize;
    public int ySize;

    public Grid gridPrefab;

    public Transform cameraTransform;

    private Dictionary<Vector2, Grid> _grids;

    public void CreateGrid()
    {
        _grids = new Dictionary<Vector2, Grid>();
        for (int i = 0; i < xSize; i++)
        {
            for(int j = 0; j < ySize; j++)
            {
                var newGrid = Instantiate(gridPrefab);
                newGrid.transform.position = new Vector2 (i, j);

                _grids[new Vector2(i,j)] = newGrid;
            }
        }

        cameraTransform.position = new Vector3(xSize * .5f - .5f, ySize * .5f - .5f, -10);
    }

    public Grid GetGrid(Vector2 key)
    {
        if (_grids.TryGetValue(key, out var grid))
        {
            return grid;
        }
        return null;
    }
}
