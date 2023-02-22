using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStates { START, GAME, PAUSE, RESTART }
    private GameStates _currentState;
    private string[] _sceneNames = { "Level1", "Level2", "Level3", "Level4 Dragon"};//Nombres de las escenas
    private int _currentScene;
    [SerializeField]
    private Transform[] _checkPoints; //Array con los checkpoints, cada escena tiene los suyos
    [SerializeField]
    private float _lifes;
    private float _currenShurikens;
    private float _maxShurikens; //Depende de la dificultad de la partida
    [SerializeField]
    private float _maxLifes; //Depende de la dificultad de la partida
    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }
    public float Lifes { get { return _lifes; } }
    public GameStates CurrentState {get { return _currentState; }} //Estado actual
    private float Maxlifes { get { return _maxLifes; } }
    
    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
        
    }
    void Start()
    {
        _currentScene = PlayerPrefs.GetInt("LevelX");
        _currentState = GameStates.GAME;
    }
    public void WinLife()
    {
        _lifes++;
    }
    public void LoseLife()
    {
        _lifes--;
    }
    public void ChangeState(GameStates newState)
    {
        _currentState = newState;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_currentState)
        {
            case GameStates.START:
                break;
            case GameStates.GAME:
                if(_lifes <= 0)
                {
                    ChangeState(GameStates.RESTART);
                }
                break;
            case GameStates.PAUSE:
                break;            
            case GameStates.RESTART:
                SceneManager.LoadScene(_sceneNames[_currentScene]);
                break;           
        }    
    }
}
