using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABountyHunter1 : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private LateralMovement _lateralMovement;
    private bool _resting;
    private bool _walking;
    private bool _shooting;
    private bool _stop;
    private bool _playerDetected;
    [SerializeField]
    private float _shootDistance;    
    [SerializeField]
    private float _attackingSpeed;
    [SerializeField]
    private float _randomStateTime;
    private float _elapsedTime = 0;
    [SerializeField]
    private float _detectionDistance;
    public Vector3 _vectorDirection;
    private int _random;
    public enum BountyHunterStates { STOP, RESTING, WALKING, ATTACKING, SHOOTING }
    public BountyHunterStates _currentState;
    // Start is called before the first frame update
    void Start()
    {
        _lateralMovement = GetComponent<LateralMovement>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void RandomState()//Elige un estado aleatorio
    {
        _random = Random.Range(0, 4);
        _playerDetected = false;
        if (_random == 0)
        {
            _currentState = BountyHunterStates.STOP;
        }
        else if (_random == 1)
        {
            _currentState = BountyHunterStates.RESTING;
        }
        else if (_random == 2 || _random == 3)
        {
            _currentState = BountyHunterStates.WALKING;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _vectorDirection = PlayerManager.Instance.transform.position - transform.position;
        _vectorDirection.Normalize();//Direccion del jugador
        if (!_playerDetected)//Si no ha detectado al jugador empieza a contar
        {
            _elapsedTime += Time.deltaTime;
        }
        if (_elapsedTime > _randomStateTime)//Al pasar un tiempo elige un comportamiento aleatorio
        {
            RandomState();
            _elapsedTime = 0;
        }
        DetectionController();
        switch (_currentState)//Ejecucion de los estados
        {
            case BountyHunterStates.STOP:
                _stop = true;
                break;
            case BountyHunterStates.RESTING:
                _resting = true;
                break;
            case BountyHunterStates.WALKING:
                _walking = true;
                _lateralMovement.enabled = true;
                break;
            case BountyHunterStates.ATTACKING:                                                                          
                transform.Translate(_vectorDirection* Time.fixedDeltaTime * _attackingSpeed);
                _walking = true;
                break;
            case BountyHunterStates.SHOOTING:
                _shooting = true;
                break;
        }
        _animator.SetBool("Idle", _stop);
        _animator.SetBool("Rest", _resting);
        _animator.SetBool("Walk", _walking);
        _animator.SetBool("Shoot", _shooting);


    }
    private void DetectionController()//Mira si hay que cambiar a atacar o disparar si el jugador se acerca
    {
        _stop = false;
        _shooting = false;
        _walking = false;
        _resting = false;
        _lateralMovement.enabled = false;
        float distance = PlayerManager.Instance.transform.position.x - transform.position.x;
        if (Mathf.Abs(distance) < _shootDistance)
        {
            _playerDetected = true;
            _currentState = BountyHunterStates.SHOOTING;
            _elapsedTime = 0;
        }
        else if (Mathf.Abs(distance) < _detectionDistance)
        {
            _playerDetected = true;
            _currentState = BountyHunterStates.ATTACKING;
        }
        else _playerDetected = false;

        if(_currentState != BountyHunterStates.WALKING)
        {
            if (distance > 0 && transform.localScale.x < 0)//Mira si hay que rotar
            {
                Turn();
            }
            if (distance < 0 && transform.localScale.x >= 0)
            {
                Turn();
            }
        }
        
    }
    public void Turn()//Rota el personaje
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }



}
