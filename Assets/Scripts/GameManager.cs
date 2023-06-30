using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float waitingDelay = 1.0f;

    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnResetGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }

    public void OnMainMenu()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", waitingDelay));
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        SceneManager.LoadScene(sceneName);
    }
}
