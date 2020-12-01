using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static GridController Instance { get; private set; }

    GridGenerator gridGenerator;
    DiagonalData diagonalData;

    public GridGenerator GridGenerator => gridGenerator;

    private void Awake()
    {
        diagonalData = new DiagonalData();

        if (Instance == null)
            Instance = this;


        gridGenerator = GetComponent<GridGenerator>();
    }

    public bool CheckAllRowsFull()
    {
        for (int y = 0; y < gridGenerator.Height; y++)
        {
            for (int x = 0; x < gridGenerator.Width; x++)
            {
                if (gridGenerator.GridItems[x, y].GridItemData.item == null)
                    return false;
            }
        }

        return true;
    }

    public bool CheckRowItemsAreSame(int row, GameState state)
    {
        for (int i = 0; i < gridGenerator.Width; i++)
        {
            var item = gridGenerator.GridItems[i, row];

            if (item.GridItemData.item == null || item.GridItemData.state != state)
                return false;
        }

        return true;
    }

    public bool CheckColumnItemsAreSame(int column, GameState state)
    {
        for (int i = 0; i < gridGenerator.Height; i++)
        {
            var item = gridGenerator.GridItems[column, i];

            if (item.GridItemData.item == null || item.GridItemData.state != state)
                return false;
        }

        return true;
    }

    bool IsValidIndex(int x, int y)
    {
        if (x < 0 || y < 0 || x >= gridGenerator.Width || y >= gridGenerator.Height)
            return false;

        return true;
    }


    public bool CheckDiagonalItemsAreSame(int indexX, int indexY, GameState state)
    {
        for (int i = 0; i < diagonalData.DiagonalCoordinates.Count; i++)
        {
            Vector2Int coordinate = diagonalData.DiagonalCoordinates[i];

            int firstIndexX = indexX + coordinate.x;
            int firstIndexY = indexY + coordinate.y;

            if (!IsValidIndex(firstIndexX, firstIndexY))
                continue;

            int secondaryIndexX = firstIndexX + coordinate.x;
            int secondaryIndexY = firstIndexY + coordinate.y;

            if (IsValidIndex(secondaryIndexX, secondaryIndexY))
            {
                var firstItem = gridGenerator.GridItems[firstIndexX, firstIndexY];
                var secondItem = gridGenerator.GridItems[secondaryIndexX, secondaryIndexY];

                if (firstItem.GridItemData.item != null && secondItem.GridItemData.item != null && firstItem.GridItemData.state == state && secondItem.GridItemData.state == state)
                    return true;
            }
            else
            {
                int reverseIndexX = indexX - coordinate.x;
                int reverseIndexY = indexY - coordinate.y;

                if (IsValidIndex(reverseIndexX, reverseIndexY))
                {
                    var firstItem = gridGenerator.GridItems[firstIndexX, firstIndexY];
                    var reverseItem = gridGenerator.GridItems[reverseIndexX, reverseIndexY];

                    if (firstItem.GridItemData.item != null && reverseItem.GridItemData.item != null && firstItem.GridItemData.state == state && reverseItem.GridItemData.state == state)
                        return true;
                }
            }
        }

        return false;
    }
}
