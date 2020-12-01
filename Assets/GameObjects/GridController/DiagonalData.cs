using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalData
{
    List<Vector2Int> diagonalCoordinates = new List<Vector2Int>();

    public DiagonalData()
    {
        InitializeDiagonalCoordinates();
    }

    public List<Vector2Int> DiagonalCoordinates => diagonalCoordinates;

    void InitializeDiagonalCoordinates()
    {
        diagonalCoordinates.Add(new Vector2Int(1, 1));
        diagonalCoordinates.Add(new Vector2Int(1, -1));
        diagonalCoordinates.Add(new Vector2Int(-1, -1));
        diagonalCoordinates.Add(new Vector2Int(-1, 1));
    }
}