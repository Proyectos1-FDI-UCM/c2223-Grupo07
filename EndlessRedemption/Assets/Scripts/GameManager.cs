using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public enum GameStates { GAME, PAUSE, RESTART }
    private GameStates _currentState;
    static private string[] _sceneNames = { "Level1", "Level2", "Level3", "Level4", "Level5"};//Nombres de las escenas
    static private int _currentScene;
    [SerializeField]
    private Transform[] _checkPoints; //Array con los checkpoints, cada escena tiene los suyos
    public int _currentCheckpoint;
    [SerializeField]
    public float _lifes;
    public float _currenShurikens;
    public float _maxShurikens; //Depende de la dificultad de la partida
    public bool _hasShurikensBag = false;
    [SerializeField]
    public float _maxLifes; //Depende de la dificultad de la partida
    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }   
    public GameStates CurrentState {get { return _currentState; }} //Estado actual
    public float Maxlifes { get { return _maxLifes; } }
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _playerDeath;
    private float _elapsedTime = 0f;
    private float _maxDeath = 3f;
    public bool _hasDeath = false;
    [SerializeField]
    private SoundManager _soundManager;
    public string[] Scenes { get { return _sceneNames; } }
    public int CurrentScene { get { return _currentScene; } }
    private void Awake()
    {
        _instance = this;
    }
    // Preparación de escena y checkpoint
    void Start()
    {
        
        Application.targetFrameRate = 144;
        _player.SetActive(true);
        _maxLifes = PlayerPrefs.GetInt("Lifes");
        if (PlayerPrefs.GetString("Modo") != "pesadilla")//para que el pesadilla sea como el antiguo que no recuperas vidas pero empiezas con 3
            _lifes = _maxLifes;
        else _lifes = 3;
        _maxShurikens = PlayerPrefs.GetInt("Shurikens");
        PlayerManager.Instance.GetComponent<InputComponent>().enabled = true;
        _currentCheckpoint = PlayerPrefs.GetInt("CheckpointX");
        for(int i = 0; i <= _currentCheckpoint; i++) //Desactivar anteriores
        {
            _checkPoints[i].gameObject.SetActive(false);
        }
        Debug.Log(PlayerPrefs.GetInt("LevelX"));
        Debug.Log("Empieza en " + _currentCheckpoint);
        PlayerManager.Instance.transform.position = new Vector3 (_checkPoints[_currentCheckpoint].position.x, _checkPoints[_currentCheckpoint].position.y, _checkPoints[_currentCheckpoint].position.z); //Mover al jugador a la posicion del checkpoint
        _currentScene = PlayerPrefs.GetInt("LevelX");
        Debug.Log(PlayerPrefs.GetString("Scene"));
        _currentState = GameStates.GAME;
        

        if(_currentScene == 0 && _currentCheckpoint == 0) PlayerPrefs.SetInt("SmokeHits", 5);//Para tener la bomba de humo al principio;
    }
    public void WinLife()
    {
        if(_lifes < _maxLifes)
        {
            _lifes++;
            Debug.Log("VIDAS: " + _lifes);
            _soundManager.SeleccionAudio(10, 0.5f);
        }
        
    }
    public void Muerte() //Para cuando cae al vacio una entidad
    {
        _lifes=0;
    }
    public void LoseLife()
    {
        if(_lifes > 0)
        _lifes--;
        UIManager.Instance.PierdeVidas();
        Debug.Log("VIDAS: " + _lifes);
        _soundManager.SeleccionAudio(11, 0.5f);
    }
    public void PickShuriken()
    {
        if(_currenShurikens < _maxShurikens)
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
            
            case GameStates.GAME:
                if(_lifes <= 0)
                {
                    if (!_hasDeath)
                    {
                        Instantiate(_playerDeath, PlayerManager.Instance.transform.position, Quaternion.identity);
                        PlayerManager.Instance.GetComponent<Renderer>().enabled = false;
                        PlayerManager.Instance.GetComponent<InputComponent>().enabled = false;
                        PlayerManager.Instance.GetComponentInChildren<GroundCollision>().enabled= false;
                        _hasDeath = true;
                    }
                    _elapsedTime += Time.deltaTime;
                    if(_elapsedTime > _maxDeath)
                    {
                        ChangeState(GameStates.RESTART);
                    }
                }           
                break;
            case GameStates.PAUSE:
                break;            
            case GameStates.RESTART:
                PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths") + 1);
                PlayerPrefs.SetInt("FirstRound", 1);
                PlayerPrefs.SetString("Scene", _sceneNames[_currentScene]);
                SceneManager.LoadScene(_sceneNames[_currentScene]);
                break;           
        }    
    }
}
