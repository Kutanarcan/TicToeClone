using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    GridItem gridItem;

    int height = 3;
    int width = 3;

    const float OFFSET = 2F;
    const float GRID_ITEM_GAP = 2.5f;

    GridItem[,] gridItems;

    public GridItem[,] GridItems => gridItems;

    public int Height => height;
    public int Width => width;

    private void Awake()
    {
        gridItems = new GridItem[width, height];
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float xOffset = (x * GRID_ITEM_GAP) - OFFSET;
                float yOffset = (y * GRID_ITEM_GAP) - OFFSET;

                GridItem tmpItem = Instantiate(gridItem, transform);
                tmpItem.IndexY = y;
                tmpItem.IndexX = x;
                tmpItem.name = $"{x},{y}";

                tmpItem.transform.position = new Vector2(xOffset, yOffset);
                gridItems[x, y] = tmpItem;
            }
        }
    }
}
