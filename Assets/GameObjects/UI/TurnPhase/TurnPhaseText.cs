using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnPhaseText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI turnText;

    void Awake()
    {
        GameStateController.OnCurrentStateChanged += GameStateController_OnCurrentStateChanged;
    }

    private void GameStateController_OnCurrentStateChanged(GameState gameState)
    {
        turnText.text = gameState.ToString();
    }

    private void OnDestroy()
    {
        GameStateController.OnCurrentStateChanged -= GameStateController_OnCurrentStateChanged;
    }
}
