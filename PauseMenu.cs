using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject GameOverMenuUI;

    public float GameOverDelay = .5f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollision.IsGameOvered)
        {
            Invoke("GameOver", 1f);
            if (Input.GetKeyDown("space"))
            {
                RestartLevel();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void RestartLevel()
    {
        GameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameIsPaused = false;
        PlayerCollision.IsGameOvered = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        GameIsPaused = false;
        PlayerCollision.IsGameOvered = false;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        SceneManager.LoadScene("Credits");
    }
    public void GameOver()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
