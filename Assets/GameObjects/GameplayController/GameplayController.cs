using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static event System.Action<string> OnGameFinished;

    bool gameFinished = false;

    void Update()
    {
        HandleItemClick();
    }

    void HandleItemClick()
    {
        if (!gameFinished && Input.GetMouseButtonDown(0))
        {
            Vector2 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(v, Vector2.zero);

            if (hit.collider)
            {
                GridItem gridItem = hit.collider.gameObject.GetComponent<GridItem>();

                if (gridItem && gridItem.GridItemData.item == null)
                {
                    gridItem.SetItem(GameStateController.Instance.CurrentState);
                    HandleSameItems(gridItem);
                    GameStateController.Instance.ChangeState();
                }
            }
        }
    }

    void HandleSameItems(GridItem gridItem)
    {

        if (   GridController.Instance.CheckRowItemsAreSame(gridItem.IndexY, GameStateController.Instance.CurrentState)
            || GridController.Instance.CheckColumnItemsAreSame(gridItem.IndexX, GameStateController.Instance.CurrentState)
            || GridController.Instance.CheckDiagonalItemsAreSame(gridItem.IndexX, gridItem.IndexY, GameStateController.Instance.CurrentState))
        {
            OnGameFinished?.Invoke($"{GameStateController.Instance.CurrentState.ToString()} WON!");

            gameFinished = true;
        }

        if (GridController.Instance.CheckAllRowsFull())
        {
            OnGameFinished?.Invoke("It's a Tie");

            gameFinished = true;
        }

    }
}
