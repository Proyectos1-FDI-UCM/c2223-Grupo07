using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SeiryuManager : MonoBehaviour
{
    //Estados
    public enum BossStates { MOLESTO, ENFADADO, FURIOSO}
    public enum AttackStates { BASICO, BOLAS, VOLCAN, PINCHOS,COLUMNAS , EMBESTIDA}
    public enum MovementStates { HUIR, RANDOM, QUIETO}
    private BossStates _currentBossState;
    private AttackStates _currentAttackState;
    private MovementStates _currentMovementState;

    #region properties
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
    private int _pinchosExplusados = 6;
    [SerializeField]
    private float _minTimeBetweenAttacks = 2f;
    [SerializeField]
    private float _maxTimeBetweenAttacks = 9f;
    [SerializeField]
    private float _pinchoSpeed = 1f;
    [SerializeField]
    private float _velocidadEmbestida = 2.5f;
    private float _timeBetweenAttacks;
    private float _basicTime = 6f;
    private float _bolasTime = 3f;
    private float _volcanTime = 2.0f;
    private float _columnasTime = 6f;
    private float _pinchosTime = 1f;
    private float _embestidaTime = 2f;
    private float _elapsedAttack = 0f;
    [SerializeField]
    private float _bolaDeFuegoSpeed = 3f;
    private int _signx;
    private int _signy;
    private int _randomcentre;
    private bool _isAttacking = false;
    private bool _goCenter;
    private bool _changeDirection;
    private bool _randomDirectionGenerated = false;
    private bool _randomCentreGenerated = false;
    private bool _bolaInstance = false;
    private bool _bolasInstance = false;
    private bool _pinchosInstance = false;
    private bool _embestida = false;

    private float _elapsedTime = 0f;
    private float _elapsedAttackTime = 0;
    private float _parabolicIndex;
    #endregion

    #region refernces
    [SerializeField]
    private Transform[] _roomCentre;
    [SerializeField]
    private GameObject _bolaDeFuego;
    private GameObject _bossUI;
    private Rigidbody2D _rigidbody2D;
    private EnemyLifeComponent _lifeComponent;
    private Vector3 _movementDirection;
    [SerializeField]
    private GameObject _pinchoPrefab;
    private BolasSeiryu _bolasSeiryu;
    [SerializeField]
    private GameObject _seiryuBar;
    private SoundManager _soundManager;
    #endregion

    //SERGIO
    [SerializeField]
    public GameObject _trayec;
    [SerializeField]
    private GameObject _puntoMedio;
    private ColumnasFuego _columnas;
    private Animator _animator;
    private ChestController _volcan;

    private bool _activeCol=false;

    static private SeiryuManager _instance;
    static public SeiryuManager Instance { get { return _instance; } }



    public void Awake()
    {
        _instance = this;
    }



    //Metodos
    public void ChooseAttack(BossStates bossState)//Seleccion de estado de ataque segun el boss state
    {
        switch (bossState)
        {
            case BossStates.MOLESTO:
                _bossSpeed = _bossSpeed1;
                if(_elapsedTime > _timeBetweenAttacks)
                {
                    _randomAttack = Random.Range(0,6);
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
                    _randomAttack = Random.Range(2, 6);
                    _currentAttackState = (AttackStates)_randomAttack;
                    EnterState(_currentAttackState);
                }                
                break;
        }
    }
    void EnterState(AttackStates attackState)//Al entrar estado de ataque
    {
        if(_currentAttackState == AttackStates.VOLCAN)
        {
            _volcan.Restart();
        }
        if (_currentAttackState == AttackStates.COLUMNAS)
        {
            _currentMovementState = MovementStates.HUIR;
            _animator.SetBool("Moving", true);
        }
        else if(_currentAttackState == AttackStates.BASICO)
        {
            _animator.SetBool("Moving", false);
            _animator.SetBool("Fire", true);
        }
        else
        {
            _animator.SetBool("Moving", false);
            _animator.SetBool("Idle", true);
            _currentMovementState = MovementStates.QUIETO;
        }

        _isAttacking = true;
        _elapsedTime = 0;
        _parabolicIndex = -3;
        _currentAttackState = attackState;
        
        _elapsedAttackTime = 0;
        Debug.Log(_currentMovementState);
        Debug.Log(_currentAttackState);
    }
    void ExitState()//al salir del estado de ataque
    {
        _volcan.enabled = false;
        _isAttacking = false;
        _randomCentreGenerated = false;
        _randomDirectionGenerated = false;
        _elapsedAttack = 0;
        _bolaInstance = false;
        _embestida = false;
        if (_goCenter)
            _currentMovementState = MovementStates.HUIR;
        else
        _currentMovementState = MovementStates.RANDOM;
        _animator.SetBool("Moving", true);
        _animator.SetBool("Idle", false);
        _animator.SetBool("Fire", false);
        _elapsedTime = 0;
        _timeBetweenAttacks = Random.Range(_minTimeBetweenAttacks, _maxTimeBetweenAttacks + 1);
        _pinchosInstance = false;
       

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
        _columnas = GetComponent<ColumnasFuego>();
        PlayerManager.Instance.GetComponent<InputComponent>().enabled = true;
        _animator = GetComponent<Animator>();
        _volcan = GetComponent<ChestController>();
        _volcan.enabled = false;
        _bolasSeiryu = GetComponent<BolasSeiryu>();
        _seiryuBar.GetComponent<SeiryuBar>().SetMaxHealth(_bossLifes);
        _soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody2D.velocity.x > 1 && transform.localScale.x < 0)//Rotacion
            Girar();
        else if (_rigidbody2D.velocity.x < 0 && transform.localScale.x > 0)
            Girar();

        ChooseAttack(_currentBossState);//Logica de selleccion de estados
        _bossLifes = _lifeComponent.vidasEnemy;//vidas actuales
        _seiryuBar.GetComponent<SeiryuBar>().SetHealth(_bossLifes);
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
                if(!_randomCentreGenerated && _currentAttackState!=AttackStates.COLUMNAS)
                {
                    _randomcentre = Random.Range(0, _roomCentre.Length);//elige al punto al que ir
                    _randomCentreGenerated = true;
                }
                  if(_currentAttackState == AttackStates.COLUMNAS)
                {
                    _randomcentre =1;
                    _randomCentreGenerated = true;
                }
                
                _movementDirection = _roomCentre[_randomcentre].position - transform.position;//direccion hacia el punto seleccionado
                _movementDirection.Normalize();
                _rigidbody2D.velocity = _movementDirection * _bossSpeed;               
                break;
        }

        if (_isAttacking)//Ataque
        {
            switch (_currentAttackState)
            {
                case AttackStates.BASICO:
                    _elapsedAttack += Time.deltaTime;
                    if (_elapsedAttack > 0.2)
                    {
                        GameObject bolaDeFuego = Instantiate(_bolaDeFuego, transform.position, Quaternion.identity);
                        Vector3 directionBola = -transform.position + PlayerManager.Instance.transform.position;
                        directionBola.Normalize();
                        bolaDeFuego.GetComponent<Rigidbody2D>().velocity = directionBola * _bolaDeFuegoSpeed;
                        _elapsedAttack = 0;
                        _soundManager.SeleccionAudio(17, 0.5f);
                        _soundManager.SeleccionAudio(18, 0.5f);
                    }
                    _elapsedAttackTime += Time.deltaTime;
                    if (_elapsedAttackTime > _basicTime) ExitState();
                    break;

                case AttackStates.BOLAS:
                    if (!_bolaInstance) {
                        _bolasSeiryu.BolasHorizontales();
                        _bolaInstance = true;
                        _bolasInstance = true;
                        _soundManager.SeleccionAudio(5, 0.5f);
                        _soundManager.SeleccionAudio(18, 0.5f);
                    }
                    _elapsedAttack += Time.deltaTime;
                    if (_elapsedAttack > 1.5 && _bolasInstance) {
                        _bolasSeiryu.BolasDiagonales();
                        _bolasInstance = false;
                        _soundManager.SeleccionAudio(5, 0.5f);
                    }
                    _elapsedAttackTime += Time.deltaTime;
                    if (_elapsedAttackTime > _bolasTime) ExitState();
                    break;

                case AttackStates.VOLCAN:
                    _volcan.enabled = true;

                    _elapsedAttackTime += Time.deltaTime;

                    if (_elapsedAttackTime > _volcanTime)
                    {
                        ExitState();
                        _soundManager.SeleccionAudio(5, 0.5f);
                        _soundManager.SeleccionAudio(18, 0.5f);
                    }
                    break;

                case AttackStates.COLUMNAS:
                    if (_activeCol)
                    {
                        _elapsedAttack += Time.deltaTime;
                        if (_elapsedAttack > 3)
                        {
                            _columnas.enabled = true;
                            _columnas.Invocar();
                            _activeCol = false;
                            _elapsedAttack = 0;
                            _soundManager.SeleccionAudio(17, 0.5f);
                        }
                       
                    }  
                    _elapsedAttackTime += Time.deltaTime;
                    if (_elapsedAttackTime > _columnasTime) ExitState();
                    break;

                case AttackStates.PINCHOS:
                    if (!_pinchosInstance) {
                        for (int i = 0; i < _pinchosExplusados; i++) {
                            GameObject pincho = Instantiate(_pinchoPrefab, transform.position, Quaternion.identity);
                            pincho.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * _pinchoSpeed;
                            _pinchosInstance = true;
                            _soundManager.SeleccionAudio(9, 0.5f);
                        }
                    }
                    _elapsedAttackTime += Time.deltaTime;
                    if (_elapsedAttackTime > _pinchosTime) ExitState();
                    break;

                case AttackStates.EMBESTIDA:
                    if (!_embestida) {
                        Vector3 directionSeiryu = PlayerManager.Instance.transform.position - transform.position;
                        directionSeiryu.Normalize();
                        GetComponent<Rigidbody2D>().velocity = directionSeiryu * _velocidadEmbestida;
                        //transform.Translate(directionSeiryu * _velocidadEmbestida);
                        _embestida = true;
                    }
                    _elapsedAttackTime += Time.deltaTime;
                    if (_elapsedAttackTime > _embestidaTime) ExitState();
                    break;
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)//Detecta si se esta chocando para huir
    {
        if (collision.gameObject.tag != "Centre")
        {
            _goCenter = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _goCenter = false;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)//Cambio de direccion durante el vuelo
    {
        if(_currentAttackState== AttackStates.COLUMNAS && collision.gameObject.tag=="Centre")
        {

            _activeCol = true;
        }
        if (collision.gameObject.tag != "Centre")
        {
            if (_changeDirection)
                _changeDirection = !_changeDirection;
            else if (!_changeDirection)
                _changeDirection = !_changeDirection;
        }
     
    }
}
