using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItem : MonoBehaviour
{
    [SerializeField]
    GameObject cross;
    [SerializeField]
    GameObject circle;

    public GridItemData GridItemData => gridItemData;
    public int IndexY { get; set; }
    public int IndexX { get; set; }

    GridItemData gridItemData = new GridItemData();
    Dictionary<GameState, GridItemData> gridItemsDict = new Dictionary<GameState, GridItemData>();

    private void Awake()
    {
        InitializeGridItemDict();
    }

    private void InitializeGridItemDict()
    {
        gridItemsDict.Add(GameState.PlayerCircleTurn, new GridItemData { item = circle, state = GameState.PlayerCircleTurn });
        gridItemsDict.Add(GameState.PlayerCrossTurn, new GridItemData { item = cross, state = GameState.PlayerCrossTurn });
    }

    public void SetItem(GameState gameState)
    {
        if (gridItemsDict.ContainsKey(gameState))
        {
            gridItemData = gridItemsDict[gameState];
            gridItemData.item.SetActive(true);
        }
    }
}

public struct GridItemData
{
    public GameObject item;
    public GameState state;
}


