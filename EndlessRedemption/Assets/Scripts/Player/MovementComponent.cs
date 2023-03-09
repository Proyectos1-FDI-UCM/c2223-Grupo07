using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
   
    private Rigidbody2D _rigidbody2D;
    private Collider2D _myCollider2D;
    private DashDetection _dashDetection;
    private InputComponent _inputComponent;
    private DashDamage _dashDamage;
    private DisableCollider _disableCollider;
    private int _fpsLimit = 144;//Para no petar el PC un saludo
    public int _jumps = 0;
    public int _jumpsAvailable = 1;
    private Vector3 _reachPosition;
    private float _distanceToReach;
    private float _timeDashing;
    [SerializeField]
    private float _maxFallSpeed;
    [SerializeField]
    private GameObject _secondJump;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _dashForce;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private float _impulse;
    [SerializeField]
    private GameObject _dashExplosion;
    private float _cooldownElapsed;
    

    public bool _onGround;
    private bool _doubleJump=false;
    public bool _dashAvailable;
    public bool _dashing;
    public bool _dashPickUp = false;
    private bool _dashCoolDown;
    private bool _lookingRight;
    [Header("Animation")]
    private Animator _animator;

    private float _time=0.5f;
    private float _elapsedtime=0f;
    #region Methods

    public void Left()
    {
        if (_rigidbody2D.velocity.x > -_maxSpeed)
        {
            _rigidbody2D.AddForce(Vector2.left * _speed * Time.fixedDeltaTime, ForceMode2D.Force);
            
        }
         
    }
    public void Right()
    {
        if (_rigidbody2D.velocity.x < _maxSpeed)
        {
            
            _rigidbody2D.AddForce(Vector2.right * _speed * Time.fixedDeltaTime, ForceMode2D.Force);
            
        }
        
    }
    public void Up()
    {
        
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        _rigidbody2D.AddForce(Vector2.up * _impulse, ForceMode2D.Force);
    }

    //Impulso inicial del salto
    public void Jump()
    {
        if (_jumps<_jumpsAvailable)
        {
            if(_jumps>0)
            {
                
                Instantiate(_secondJump, transform.position, Quaternion.identity);
                _doubleJump =true;
                _animator.SetBool("DoubleJump", _doubleJump);
            }
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(Vector2.up * _jumpForce , ForceMode2D.Impulse);
            _jumps++;
        }
    }
    public void Dash()
    {
        if (_dashPickUp && !_dashCoolDown)
        {
            _disableCollider.Collider();
            gameObject.layer = 8;
            _reachPosition = _dashDetection.PositionToReach;
            _dashCoolDown = true;
            if (_dashAvailable)
            {
                _inputComponent.enabled = false;
                _rigidbody2D.gravityScale = 0;
                _myCollider2D.enabled = false;
                
            }
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            if (_lookingRight)
            {
                GameObject item=Instantiate(_dashExplosion, transform.position, Quaternion.identity);
                //item.transform.parent = transform;
                _myCollider2D.enabled = false;
                _rigidbody2D.AddForce(Vector2.right * _dashForce, ForceMode2D.Impulse);
            }
            else if (!_lookingRight)
            {
                GameObject item = Instantiate(_dashExplosion, transform.position, Quaternion.identity);
                //item.transform.parent = transform;
                _myCollider2D.enabled = false;
                _rigidbody2D.AddForce(Vector2.left * _dashForce, ForceMode2D.Impulse);
            }
            _dashing = true;
        }
    }
    private void Girar()
    {
        _dashDetection.DashDirection();
        _dashDamage.DamageDirection();
        _lookingRight = !_lookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }
    public void DashStop()
    {
        _disableCollider.ColliderEnable();
        gameObject.layer = 3;
        _dashing = false;
        _myCollider2D.enabled = true;
        _rigidbody2D.gravityScale = 4;
        _inputComponent.enabled = true;
    }

    public void DecreaseFallSpeed(int decrement)
    {
        _maxFallSpeed += decrement;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = _fpsLimit;//limitador, no quitar
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _dashDetection = GetComponentInChildren<DashDetection>();
        _inputComponent = GetComponent<InputComponent>();
        _disableCollider = GetComponentInChildren<DisableCollider>();
        _onGround = true;        
        _myCollider2D = GetComponent<Collider2D>();
        _dashAvailable = true;
        _dashing = false;
        _distanceToReach = 0.3f;
        _lookingRight = true;
        _animator = GetComponent<Animator>();
        _dashDamage = FindObjectOfType<DashDamage>();

        _dashCoolDown = false;

    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("hasDash") == 1) _dashPickUp = true;
        if (PlayerPrefs.GetInt("hasDoubleJump") == 1) _jumpsAvailable = 2;
        ;
        if (_rigidbody2D.velocity.y < _maxFallSpeed)
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _maxFallSpeed);
        if(_dashCoolDown)
        {           
            _cooldownElapsed += Time.deltaTime;
            Debug.Log("DASH CD: " + _cooldownElapsed);
        }
        if(_cooldownElapsed > _cooldown)
        {
            _cooldownElapsed = 0;
            _dashCoolDown = false;
        }
        _animator.SetFloat("Horizontal", Mathf.Abs(_rigidbody2D.velocity.x));
        _animator.SetBool("OnGround", _onGround);
        _animator.SetBool("Dashing", _dashing);
        if (_rigidbody2D.velocity.x > 1 && !_lookingRight)
        { 
            Girar(); 
        }
        else if (_rigidbody2D.velocity.x < -1 && _lookingRight)
        {
            Girar();           
        }
        if (_dashing && Mathf.Sqrt(Mathf.Pow(_reachPosition.x - transform.position.x, 2f) + Mathf.Pow(_reachPosition.y - transform.position.y, 2f)) < _distanceToReach)
        {
            DashStop();
            if (_lookingRight)
            {
                _rigidbody2D.AddForce(Vector2.left * (_dashForce - _maxSpeed), ForceMode2D.Impulse);
            }
            else if (!_lookingRight)
            {
                _rigidbody2D.AddForce(Vector2.right * (_dashForce - _maxSpeed), ForceMode2D.Impulse);
            }
        }
        if(!_dashing)_myCollider2D.enabled = true;

        if (_doubleJump)
        {
            _elapsedtime += Time.deltaTime;
            if(_elapsedtime > _time)
            {
                _doubleJump = false;
                _animator.SetBool("DoubleJump", _doubleJump);
                _elapsedtime = 0;
            }
        }
    }   
    
}
