using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public static GameStateController Instance { get; private set; }

    GameState currentState;
    Queue<GameState> gameStates = new Queue<GameState>();

    public GameState CurrentState => currentState;

    public static event System.Action<GameState> OnCurrentStateChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        currentState = GameState.PlayerCrossTurn;
        gameStates.Enqueue(GameState.PlayerCircleTurn);
    }

    public void ChangeState()
    {
        gameStates.Enqueue(currentState);
        currentState = gameStates.Dequeue();
        OnCurrentStateChanged?.Invoke(currentState);
    }
}

public enum GameState
{
    PlayerCircleTurn,
    PlayerCrossTurn
}