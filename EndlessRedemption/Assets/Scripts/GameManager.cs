using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStates { START, GAME, PAUSE, RESTART }
    private GameStates _currentState;
    private string[] _sceneNames = { "cazarrecopensas", "Level2", "Level3", "Level4 Dragon"};//Nombres de las escenas
    private int _currentScene;
    [SerializeField]
    private Transform[] _checkPoints; //Array con los checkpoints, cada escena tiene los suyos
    public int _currentCheckpoint;
    [SerializeField]
    public float _lifes;
    public float _currenShurikens;
    public float _maxShurikens; //Depende de la dificultad de la partida
    [SerializeField]
    public float _maxLifes; //Depende de la dificultad de la partida
    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }   
    public GameStates CurrentState {get { return _currentState; }} //Estado actual
    public float Maxlifes { get { return _maxLifes; } }
    
    private void Awake()
    {
        _instance = this;
    }
    // Preparación de escena y checkpoint
    void Start()
    {
        _currentCheckpoint = PlayerPrefs.GetInt("CheckpointX");
        for(int i = 0; i <= _currentCheckpoint; i++) //Desactivar anteriores
        {
            _checkPoints[i].gameObject.SetActive(false);
        }
        Debug.Log("Empieza en " + _currentCheckpoint);
        PlayerManager.Instance.transform.position = new Vector3 (_checkPoints[_currentCheckpoint].position.x, _checkPoints[_currentCheckpoint].position.y, _checkPoints[_currentCheckpoint].position.z); //Mover al jugador a la posicion del checkpoint
        _currentScene = PlayerPrefs.GetInt("LevelX");
        _currentState = GameStates.GAME;
    }
    public void WinLife()
    {
        _lifes++;
        UIManager.Instance.GanaVidas();
        Debug.Log("VIDAS: "+ _lifes);
    }
    public void Muerte() //Para cuando cae al vacio una entidad
    {
        _lifes=0;
    }
    public void LoseLife()
    {
        _lifes--;
        UIManager.Instance.PierdeVidas();
        Debug.Log("VIDAS: " + _lifes);
    }
    public void PickShuriken()
    {
        _currenShurikens += 5;
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
