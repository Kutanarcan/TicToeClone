using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameFinishedMenu : MonoBehaviour
{
    [SerializeField]
    GameObject gameFinishedPanel;
    [SerializeField]
    TextMeshProUGUI gameFinishedText;

    private void Awake()
    {
        GameplayController.OnGameFinished += GameplayController_OnGameFinished;
    }

    private void GameplayController_OnGameFinished(string message)
    {
        gameFinishedPanel.SetActive(true);
        gameFinishedText.text = message;
    }

    public void OnPlayAgainButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        GameplayController.OnGameFinished -= GameplayController_OnGameFinished;
    }
}
