using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SmokeBomb : MonoBehaviour
{
    [SerializeField]
    private GameObject _bomb;  
    public float _elapsedTime;
    private float _cooldownElapsed;
    [SerializeField]
    private float _smokeTime;
    [SerializeField]
    private float _coolDown;
    private bool _smokeActive;
    private bool _smokeAvailable;
    [Header("Animation")]
    private Animator _animator;
    private GameObject _instanced;
    public Vector3 _smokePosition;
    private int _hitsToCharge = 5;
    public bool _playerTarget = true;
    public float SmokeCoolDown { get { return _coolDown; } }

    private SoundManager _soundManager;
    // Start is called before the first frame update
    void Start()
    {
        _smokeAvailable = false;
        _elapsedTime = 0;
        _cooldownElapsed = 0;
        _smokeActive = false;
        _animator = GetComponent<Animator>();
        _soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_smokeActive)
        {
            _elapsedTime += Time.deltaTime;
        }
        
        if (PlayerPrefs.GetInt("SmokeHits") >= _hitsToCharge)
        {           
            _smokeAvailable = true;
        }
        
        if(_elapsedTime > _smokeTime)
        {
            _smokeAvailable = false;
            _smokeActive = false;
            _elapsedTime = 0;
            _playerTarget = true;
        }
        if (_elapsedTime > 0.5)
        {
            Destroy(_instanced);
        }
    }
    public void ActivateSmoke()
    {
        if(_smokeAvailable && !_smokeActive)
        {
            PlayerPrefs.SetInt("SmokeHits", 0);
            GameManager.Instance.WinLife();
            PlayerManager.Instance.Invulnerable(3);
            _instanced =  Instantiate(_bomb, transform.position, Quaternion.identity);
            _smokeActive = true;
            _playerTarget = false;
            _smokePosition = transform.position;
            _soundManager.SeleccionAudio(2, 0.5f);
        }
    }
}
