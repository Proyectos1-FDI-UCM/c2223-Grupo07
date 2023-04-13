using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region properties
     public bool _isPaused = false;   
    #endregion

    #region references
    [SerializeField]
    private GameObject _Canvas;
    private InputComponent _myInputComponent;
    private PausaInput _myPausaInput;
    static private PauseMenu _instance;
    static public PauseMenu Instance { get { return _instance; } }
    #endregion

    #region methods
    public void PauseGame()//Objeto del menú
    {
        _Canvas.SetActive(true);
        _myInputComponent = PlayerManager.Instance.GetComponent<InputComponent>();       
        _myInputComponent.enabled = false; 
        Time.timeScale = 0f;
        _isPaused = true;
        
    }

    public void ResumeGame()
    {
        _Canvas.SetActive(false);
        _myInputComponent = PlayerManager.Instance.GetComponent<InputComponent>();
        _myInputComponent.enabled = true;   
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void PauseQuit()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    #endregion
    private void Awake()
    {      
        _instance = this;
    }
}
