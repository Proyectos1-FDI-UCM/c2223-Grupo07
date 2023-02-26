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
    private int _fpsLimit = 144;//Para no petar el PC un saludo
    [HideInInspector]
    public int _jumps = 0;
    public int _jumpsAvailable = 1;
    private Vector3 _reachPosition;
    private float _distanceToReach;
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
    private float _impulse=5;
    private float _cooldownElapsed;
    
    [HideInInspector]
    public bool _onGround;
    public bool _dashAvailable;
    public bool _dashing;
    public bool _dashPickUp = false;
    private bool _dashCoolDown;
    private bool _lookingRight;
    [Header("Animation")]
    private Animator _animator;
   

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
        Debug.Log("e");
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        _rigidbody2D.AddForce(Vector2.up * _impulse, ForceMode2D.Force);
    }

    //Impulso inicial del salto
    public void Jump()
    {
        if (_jumps<_jumpsAvailable)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(Vector2.up * _jumpForce , ForceMode2D.Impulse);
            _jumps++;
        }
    }
    public void Dash()
    {
        if (_dashPickUp && !_dashCoolDown)
        {
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
                _rigidbody2D.AddForce(Vector2.right * _dashForce, ForceMode2D.Impulse);
            }
            else if (!_lookingRight)
            {
                _rigidbody2D.AddForce(Vector2.left * _dashForce, ForceMode2D.Impulse);
            }
            _dashing = true;

        }
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = _fpsLimit;//limitador, no quitar
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _dashDetection = GetComponentInChildren<DashDetection>();
        _inputComponent = GetComponent<InputComponent>();
        _onGround = true;        
        _myCollider2D = GetComponent<Collider2D>();
        _dashAvailable = true;
        _dashing = false;
        _distanceToReach = 1f;
        _lookingRight = true;
        _animator = GetComponent<Animator>();
        _dashDamage = FindObjectOfType<DashDamage>();
        _dashCoolDown = false;
        
        
        
       
    }
    private void Update()
    {
       
        if(_dashCoolDown)
        {           
            _cooldownElapsed += Time.deltaTime;
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
    }
           
        
        
    
    private void Girar ()
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
        gameObject.layer = 3;
        _dashing = false;
        _myCollider2D.enabled = true;
        _rigidbody2D.gravityScale = 4;
        _inputComponent.enabled = true;
    }
}
