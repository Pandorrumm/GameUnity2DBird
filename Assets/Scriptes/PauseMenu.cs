using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused;
    public GameObject pauseMenuUi;

    private void Start()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
    }
    //public void GamePause()
    //{
    //    GameIsPaused = !GameIsPaused;
    //    if (GameIsPaused)
    //        Time.timeScale = 0;
    //    if (!GameIsPaused)
    //        Time.timeScale = 1;

    //}

    //private void OnApplicationPause()
    //{
    //    GameIsPaused = true;
    //    Time.timeScale = 0;
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
