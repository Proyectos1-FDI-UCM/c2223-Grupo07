using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDragon : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private LateralMovement _lateralMovement;
    private bool _resting;
    private bool _walking;
    private bool _shooting;
    private bool _attacking=false;
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
    public enum DragonStates { RESTING, WALKING, ATTACKING, SHOOTING }
    public DragonStates _currentState;

    // Start is called before the first frame update
    void Start()
    {
        _lateralMovement = GetComponent<LateralMovement>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void RandomState()//Elige un estado aleatorio
    {
        _random = Random.Range(0, 3);
        
        if (_random == 0)
        {
            _currentState = DragonStates.RESTING;
        }
        else if (_random == 1 || _random == 2)
        {
            _currentState = DragonStates.WALKING;
        }
    }
    // Update is called once per frame
    void Update()
    {
        _vectorDirection = PlayerManager.Instance.transform.position - transform.position;
        _vectorDirection.Normalize();
        //if(!_playerDetected )
       // {
            //_elapsedTime += Time.deltaTime;
            //if (_elapsedTime > _randomStateTime)
            //{
               // RandomState();
                //_elapsedTime = 0;
            //}
        //}
        DetectionController();
        switch (_currentState)//Ejecucion de los estados
        {
            case DragonStates.RESTING:
                _resting = true;
                _attacking = false;
                break;
            case DragonStates.WALKING:
                _walking = true;
                _attacking = false;
                _lateralMovement.enabled = true;
                break;
            case DragonStates.ATTACKING:
                if((PlayerManager.Instance.transform.position.x - transform.position.x) <= 0)
                {
                    Vector3 target = new Vector3(PlayerManager.Instance.transform.position.x, PlayerManager.Instance.transform.position.y);
                    Vector3 Trayectoria = target - transform.position;
                    Trayectoria.Normalize();
                    transform.Translate(Trayectoria * Time.fixedDeltaTime * _attackingSpeed);
                    _walking = true;
                    _attacking = true;
                }
                else if ((PlayerManager.Instance.transform.position.x - transform.position.x) > 0)
                {

                    Vector3 target = new Vector3(PlayerManager.Instance.transform.position.x,PlayerManager.Instance.transform.position.y);
                    Vector3 Trayectoria = target - transform.position;
                    Trayectoria.Normalize();
                    transform.Translate(Trayectoria * Time.fixedDeltaTime * _attackingSpeed);
                    _walking = true;
                    _attacking = true;
                }
               
                break;
            case DragonStates.SHOOTING:
                if(Mathf.Abs(PlayerManager.Instance.transform.position.x - transform.position.x) < 1.5)
                {
                    _attacking = false;
                }else _attacking = true;
                _shooting = true;
                break;
        }
        
        _animator.SetBool("Rest", _resting);
        _animator.SetBool("Walk", _walking);
        _animator.SetBool("Shoot", _shooting);
        _animator.SetBool("Attacking", _attacking);

    }
    private void DetectionController()
    {
        _shooting = false;
        _walking = false;
        _resting = false;
        _lateralMovement.enabled = false;

        float distanceX = PlayerManager.Instance.transform.position.x - transform.position.x;
        float distanceY = PlayerManager.Instance.transform.position.y - transform.position.y;

        if (Mathf.Abs(distanceX)<= _shootDistance && Mathf.Abs(distanceY) <= _shootDistance)
        {
            _playerDetected = true;
            _currentState = DragonStates.SHOOTING;
            _elapsedTime = 0;
        }
        else if (Mathf.Abs(distanceX) < _detectionDistance && Mathf.Abs(distanceY) < _detectionDistance)
        {
            _playerDetected = true;
            _currentState = DragonStates.ATTACKING;
        }
        else _playerDetected = false;

        if (_currentState != DragonStates.WALKING)
        {
            if (_vectorDirection.x > 0 && transform.localScale.x > 0)
            {
                Turn();
            }
            if (_vectorDirection.x < 0 && transform.localScale.x < 0)
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
