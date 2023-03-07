using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region properties
    public static bool isPaused = false;
    #endregion

    #region references
    [SerializeField]
    private GameObject _playerObject;
    private InputComponent _myInputComponent;
    #endregion

    public void PauseGame(GameObject pauseMenuUI)//Objeto del menú
    {
        _myInputComponent = _playerObject.GetComponent<InputComponent>();
        _myInputComponent.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused= true;
    }

    public void ResumeGame(GameObject pauseMenuUI)
    {
        _myInputComponent = _playerObject.GetComponent<InputComponent>();
        _myInputComponent.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused= false;
    }

    public void PauseQuit()
    {
        SceneManager.LoadScene(0);
    }
}
