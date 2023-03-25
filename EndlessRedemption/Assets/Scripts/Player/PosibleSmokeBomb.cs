using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosibleSmokeBomb : MonoBehaviour
{
    [SerializeField]
    private GameObject _bomb;
    private EnemyLifeComponent _enemyLifeComponent;
    public float _elapsedTime;
    private float _enemiesDead;
    [SerializeField]
    private float _smokeTime;
    [SerializeField]
    private float _enemiesNecessary;
    private bool _smokeActive;
    private bool _smokeAvailable;
    [Header("Animation")]
    private Animator _animator;
    private GameObject _instanced;
    public Vector3 _smokePosition;
    public bool _playerTarget = true;
    public float SmokeCoolDown { get { return _enemiesNecessary; } }

    private SoundManager _soundManager;
    // Start is called before the first frame update
    void Start()
    {
        _smokeAvailable = true;
        _elapsedTime = 0;
        _enemiesDead = 0;
        _smokeActive = false;
        _animator = GetComponent<Animator>();
        _enemyLifeComponent = FindObjectOfType<EnemyLifeComponent>();
        _soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_smokeActive) // Se activa la bomba
        {
            _elapsedTime += Time.deltaTime;
        }
        else if (!_smokeActive && _enemyLifeComponent.MuerteBool())
        {
            _enemiesDead++;
            Debug.Log("Carga del smoke: " + _enemiesDead);
        }
        if (_enemiesDead > _enemiesNecessary) // Termina el cooldown
        {
            _enemiesDead = 0;
            _smokeAvailable = true;
            Debug.Log("Smoke disponible");
        }

        if (_elapsedTime > _smokeTime) // Termina la inmunidad
        {
            _smokeAvailable = false;
            _smokeActive = false;
            _elapsedTime = 0;
            _playerTarget = true;
        }
        if (_elapsedTime > 0.5)  // Termina la animación
        {
            Destroy(_instanced);
        }
    }
    public void ActivateSmoke()
    {
        if (_smokeAvailable && !_smokeActive)
        {
            PlayerManager.Instance.Invulnerable(3);
            _instanced = Instantiate(_bomb, transform.position, Quaternion.identity);
            _smokeActive = true;
            _playerTarget = false;
            _smokePosition = transform.position;
            _soundManager.SeleccionAudio(2, 0.5f);
        }
    }

}
