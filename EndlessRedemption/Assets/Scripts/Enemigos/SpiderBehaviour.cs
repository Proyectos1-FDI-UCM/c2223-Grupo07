using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBehaviour : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField]
    private float _detectionDistance = 0;
    [SerializeField]
    private float _detectionDistanceY = 0;
    private Rigidbody2D _myRigidbody;
    private bool _onGround = false;
    private bool _attacking;
    private BoxCollider2D _myBoxcollider;
    private Vector2 _vectorDirection;
    [SerializeField]
    private float _enemySpeed = 1f;
    private Animator _animator;
    private SmokeBomb _mySmokeBomb;
    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = PlayerManager.Instance.transform;
        _myRigidbody = GetComponent<Rigidbody2D>();
        _myRigidbody.gravityScale = 0;
        _myBoxcollider = GetComponent<BoxCollider2D>();
        _myBoxcollider.enabled = false;
        _animator = GetComponent<Animator>();
        _mySmokeBomb = FindObjectOfType<SmokeBomb>();
        _attacking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _vectorDirection = _playerTransform.position - transform.position;
        _vectorDirection.Normalize();
        if (Mathf.Abs(_playerTransform.position.x - transform.position.x) < _detectionDistance && _myRigidbody.gravityScale == 0 && Mathf.Abs(_playerTransform.position.y - transform.position.y) < _detectionDistanceY)
        {
            _myRigidbody.gravityScale = 1;
            _myBoxcollider.enabled = true;
            transform.localScale = new Vector2(transform.localScale.x, -transform.localScale.y);
        }
        else if (_myRigidbody.gravityScale == 1 && _onGround == true && _mySmokeBomb._playerTarget)
        {
            _attacking = true;
            transform.Translate(-_vectorDirection * Time.fixedDeltaTime * _enemySpeed);
            if (_vectorDirection.x > 0 && transform.localScale.x < 0)
            {
                Girar();
            }
            if (_vectorDirection.x < 0 && transform.localScale.x > 0)
            {
                Girar();
            }
        }
        else if (!_mySmokeBomb._playerTarget && _myRigidbody.gravityScale == 1 && _onGround == true)
        {
            _vectorDirection = _mySmokeBomb._smokePosition - transform.position;
            _vectorDirection.Normalize();
            transform.Translate(-_vectorDirection * Time.fixedDeltaTime * _enemySpeed);
            if (_vectorDirection.x > 0 && transform.localScale.x > 0)
            {
                Girar();
            }
            if (_vectorDirection.x < 0 && transform.localScale.x < 0)
            {
                Girar();
            }
        }
        else _attacking = false;
        _animator.SetBool("attacking", _attacking);
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            _onGround = true;
        }
    }
    private void Girar()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
