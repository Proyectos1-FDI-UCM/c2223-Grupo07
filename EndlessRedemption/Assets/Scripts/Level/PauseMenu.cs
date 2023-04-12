using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region properties
    public bool _isPaused = false;
    //public bool getPaused(){ return _isPaused; }
    #endregion

    #region references
    [SerializeField]
    private GameObject _playerObject;
    private InputComponent _myInputComponent;
    private PausaInput _myPausaInput;
    static private PauseMenu _instance;
    static public PauseMenu Instance { get { return _instance; } }
    #endregion

    #region methods
    public void PauseGame(GameObject pauseMenuUI)//Objeto del menú
    {
        _myInputComponent = _playerObject.GetComponent<InputComponent>();
        _myPausaInput = _playerObject.GetComponent<PausaInput>();
        _myInputComponent.enabled = false;
        _myPausaInput.enabled = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused= true;
    }

    public void ResumeGame(GameObject pauseMenuUI)
    {
        _myInputComponent = _playerObject.GetComponent<InputComponent>();
        _myPausaInput = _playerObject.GetComponent<PausaInput>();
        _myInputComponent.enabled = true;
        _myPausaInput.enabled = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isPaused= false;
    }

    public void PauseQuit()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
    private void Awake()
    {
        _instance = this;
    }
}
