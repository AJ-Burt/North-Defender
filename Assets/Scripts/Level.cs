using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] float gameOverDelay = 1f;

	public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        var gameSession = FindObjectOfType<GameSession>();
        if (gameSession)
            gameSession.ResetGame();
    }


    public void LoadGameOver()
    {
        StartCoroutine(DeferLoadGameOver());
    }

    IEnumerator DeferLoadGameOver()
    {
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
