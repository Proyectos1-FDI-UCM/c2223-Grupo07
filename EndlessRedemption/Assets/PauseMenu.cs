using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public void PauseGame(GameObject pauseMenuUI)//Objeto del menú
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused= true;
    }

    public void ResumeGame(GameObject pauseMenuUI)
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused= false;
    }

    public void PauseQuit()
    {
        SceneManager.LoadScene(0);
    }
}
