using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenuScript : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject gamewonUI;

    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        isGamePaused = false;

    }
    public void Pause()
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        isGamePaused = true;
    }
    public void GameOver()
    {

        gameOverUI.SetActive(true);
        Time.timeScale = 0.0f;
        isGamePaused = true;
    }
    public void GameWon()
    {

        gamewonUI.SetActive(true);
        Time.timeScale = 0.0f;
        isGamePaused = true;
    }
    public void LoadMainMenu()
    {
        isGamePaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
