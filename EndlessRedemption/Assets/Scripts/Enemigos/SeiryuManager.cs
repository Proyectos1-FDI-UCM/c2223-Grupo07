using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiryuManager : MonoBehaviour
{
    //Estados
    public enum BossStates { MOLESTO, ENFADADO, FURIOSO}
    public enum AttackStates { BASICO, BOLAS,VOLCAN, COLUMNAS, PINCHOS, EMBESTIDA}
    public enum MovementStates { HUIR, RANDOM, QUIETO}
    private BossStates _currentBossState;
    private AttackStates _currentAttackState;
    private MovementStates _currentMovementState;


    //Propiedades
    
    private float _bossSpeed = 1.0f;
    [SerializeField]
    private float _bossSpeed1;
    [SerializeField]
    private float _bossSpeed2;
    [SerializeField]
    private float _bossSpeed3;
    private int _bossLifes = 60;
    private int _randomAttack;
    [SerializeField]
    private float _minTimeBetweenAttacks = 2f;
    [SerializeField]
    private float _maxTimeBetweenAttacks = 9f;
    private float _timeBetweenAttacks;
    private float _basicTime = 6f;
    private float _bolasTime = 3f;
    private float _columnasTime = 10f;
    private float _pinchosTime = 1f;
    private float _embestidaTime = 2f;
    private int _signx;
    private int _signy;
    private int _randomcentre;
    private bool _isAttacking = false;
    private bool _goCenter;
    private bool _changeDirection;
    private bool _randomDirectionGenerated = false;
    private bool _randomCentreGenerated = false;
    private Vector3 _movementDirection;
    


    private float _elapsedTime = 0f;
    private float _elapsedAttackTime = 0;
    private float _parabolicIndex;

    //Referencias
    [SerializeField]
    private Transform[] _roomCentre;
    private GameObject _bossUI;
    private Rigidbody2D _rigidbody2D;
    private EnemyLifeComponent _lifeComponent;

    //Metodos
    public void ChooseAttack(BossStates bossState)//Seleccion de estado de ataque segun el boss state
    {
        switch (bossState)
        {
            case BossStates.MOLESTO:
                _bossSpeed = _bossSpeed1;
                if(_elapsedTime > _timeBetweenAttacks)
                {
                    _randomAttack = Random.Range(0, 2);
                    _currentAttackState = (AttackStates)_randomAttack;//Elige ataque random
                    EnterState(_currentAttackState);
                }             
                break;
            case BossStates.ENFADADO:
                _bossSpeed = _bossSpeed2;
                if (_elapsedTime > _timeBetweenAttacks)
                {
                    _randomAttack = Random.Range(1, 4);
                    _currentAttackState = (AttackStates)_randomAttack;
                    EnterState(_currentAttackState);
                }                  
                break;
            case BossStates.FURIOSO:
                _bossSpeed = _bossSpeed3;
                if (_elapsedTime > _timeBetweenAttacks)
                {
                    _randomAttack = Random.Range(0, 6);
                    _currentAttackState = (AttackStates)_randomAttack;
                    EnterState(_currentAttackState);
                }                
                break;
        }
    }
    void EnterState(AttackStates attackState)//Al entrar estado de ataque
    {
       
        _isAttacking = true;
        _elapsedTime = 0;
        _parabolicIndex = -3;
        _currentAttackState = attackState;
        _currentMovementState = MovementStates.QUIETO;
        _elapsedAttackTime = 0;
        Debug.Log(_currentAttackState);
    }
    void ExitState()//al salir del estado de ataque
    {
        _isAttacking = false;
        _randomCentreGenerated = false;
        _randomDirectionGenerated = false;
        if (_goCenter)
            _currentMovementState = MovementStates.HUIR;
        else
        _currentMovementState = MovementStates.RANDOM;
        _elapsedTime = 0;
        _timeBetweenAttacks = Random.Range(_minTimeBetweenAttacks, _maxTimeBetweenAttacks + 1);
        Debug.Log(_currentMovementState);
    }
    public void Girar()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Start is called before the first frame update
    void Start()
    {
        _lifeComponent = GetComponent<EnemyLifeComponent>();
        _currentMovementState = MovementStates.QUIETO;//Se inicia quieto
        _timeBetweenAttacks = Random.Range(_minTimeBetweenAttacks, _maxTimeBetweenAttacks + 1);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _currentBossState = BossStates.MOLESTO;//Empieza en el estado molesto
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody2D.velocity.x > 0 && transform.localScale.x < 0)//Rotacion
            Girar();
        else if (_rigidbody2D.velocity.x < 0 && transform.localScale.x > 0)
            Girar();

        ChooseAttack(_currentBossState);//Logica de selleccion de estados
        _bossLifes = _lifeComponent.vidasEnemy;//vidas actuales       
        if(!_isAttacking)
        {
            _elapsedTime += Time.deltaTime;//Si no esta atacando empieza a contar para hacer el proximo ataque
        }
        if(_bossLifes <= 20)//Cambio a estado segun las vidas
        {
            _currentBossState = BossStates.FURIOSO;
        }
        else if(_bossLifes <= 40 )
        {
            _currentBossState = BossStates.ENFADADO;
        }
        switch(_currentMovementState)
        {
            case MovementStates.QUIETO:
                _rigidbody2D.velocity = Vector2.zero;//Se para
                break;
            case MovementStates.RANDOM://Hace una "parabola" random
                _parabolicIndex += Time.deltaTime;
                if(!_randomDirectionGenerated)
                {
                    _randomDirectionGenerated = true;
                    _movementDirection.x = Random.Range(4, 6);//Seleccion de vector
                    _movementDirection.y = Random.Range(4, 6);
                    _signx = Random.Range(0, 2);//Seleccion de signo
                    _signy = Random.Range(0, 2);
                    Debug.Log(""+_movementDirection+ _signx + _signy);
                }            
                _movementDirection = new Vector3(Mathf.Pow(_movementDirection.x * _parabolicIndex, 2), Mathf.Pow(_movementDirection.y * _parabolicIndex, 2), 0);               
                    if (_signx == 1)
                        _movementDirection.x *= -1;
                    if (_signy == 1)
                        _movementDirection.y *= -1;
                if (_changeDirection)
                {
                    _movementDirection *= -1;//Si se choca gira
                }                
                _movementDirection.Normalize();
                                              
                _rigidbody2D.velocity = _movementDirection * _bossSpeed;//Movimiento
                break;
            case MovementStates.HUIR:
                if(!_randomCentreGenerated)
                {
                    _randomcentre = Random.Range(0, _roomCentre.Length + 1);//elige al punto al que ir
                    _randomCentreGenerated = true;
                }               
                _movementDirection = _roomCentre[_randomcentre-1].position - transform.position;//direccion hacia el punto seleccionado
                _movementDirection.Normalize();
                _rigidbody2D.velocity = _movementDirection * _bossSpeed;               
                break;
        }

        if (_isAttacking)//Ataque
        {
            switch (_currentAttackState)
            {
                case AttackStates.BASICO:
                    _elapsedAttackTime += Time.deltaTime;
                    if(_elapsedAttackTime > _basicTime)
                    {
                        ExitState();
                    }
                    break;
                case AttackStates.BOLAS:
                    _elapsedAttackTime += Time.deltaTime;
                    if (_elapsedAttackTime > _bolasTime)
                    {
                        ExitState();
                    }
                    break;
                case AttackStates.COLUMNAS:
                    _elapsedAttackTime += Time.deltaTime;
                    if (_elapsedAttackTime > _columnasTime)
                    {
                        ExitState();
                    }
                    break;
                case AttackStates.PINCHOS:
                    _elapsedAttackTime += Time.deltaTime;
                    if (_elapsedAttackTime > _pinchosTime)
                    {
                        ExitState();
                    }
                    break;
                case AttackStates.EMBESTIDA:
                    _elapsedAttackTime += Time.deltaTime;
                    if (_elapsedAttackTime > _embestidaTime)
                    {
                        ExitState();
                    }
                    break;
            }

        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)//Detecta si se esta chocando para huir
    {
        _goCenter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _goCenter = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)//Cambio de direccion durante el vuelo
    {
        if (_changeDirection)
            _changeDirection = !_changeDirection;
        else if (!_changeDirection)
            _changeDirection = !_changeDirection;
    }
}
