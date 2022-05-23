using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;

    public static bool isGameOver;

    void Start()
    {
        isGameOver = false;
        gameOverMenu.SetActive(false);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
        Cursor.visible = true;
    }

    public void PlayAgain()
    {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        isGameOver = false;
        Cursor.visible = false;

        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


}
