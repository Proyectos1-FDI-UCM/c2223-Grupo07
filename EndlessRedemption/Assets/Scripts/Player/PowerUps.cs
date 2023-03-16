using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private InputComponent _inputComponent;
    private Transform _transform;
    private Animator _animator;

    private GameObject _item;

    [SerializeField]
    private GameObject _ToFresco;
    
    public Transform _objetive;

    private float _movementSpeed=5f;

    private bool _powerUp = true;

    [SerializeField]
    private float _time=3f;
    
    private float _elapsedtime;

    [SerializeField]
    private float _time2=7f;
    
    private float _elapsedtime2;

    public bool _dash=false;

    public bool _dJump=false;

    void Start()
    {
        
        _transform = transform;
        _transform.position = new Vector2(_objetive.position.x, _objetive.position.y);
        _rigid = GetComponent<Rigidbody2D>();
        _inputComponent =  GetComponent<InputComponent>();
        _inputComponent.enabled = false;
        _rigid.velocity = new Vector2(0, 0);
        _rigid.gravityScale = 0;
        _animator= GetComponent<Animator>();
        _animator.SetBool("PowerUp", _powerUp);

    }

    // Update is called once per frame
    void Update()
    {
        if (_dJump)
        {
            _elapsedtime2 += Time.deltaTime;
            _elapsedtime += Time.deltaTime;

            if (_elapsedtime >= _time)
            {
                _item = Instantiate(_ToFresco, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            }

            if (_elapsedtime2 >= _time2)
            {
                _elapsedtime2 = 0;
                _inputComponent.enabled = true;
                _rigid.gravityScale = 4;
                _powerUp = false;
                _animator.SetBool("PowerUp", _powerUp);
                Destroy(_item);
                this.enabled = false;
            }
        }
        else if (_dash)
        {
            _elapsedtime2 += Time.deltaTime;
            _elapsedtime += Time.deltaTime;

            if (_elapsedtime2 >= _time2)
            {
                _elapsedtime2 = 0;
                _inputComponent.enabled = true;
                _rigid.gravityScale = 4;
                _powerUp = false;
                _animator.SetBool("PowerUp", _powerUp);
                Destroy(_item);
                this.enabled = false;
            }
        }
   
    }
}
