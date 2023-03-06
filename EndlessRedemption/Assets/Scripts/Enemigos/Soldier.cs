using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private Animator _animator;
    private EnemyDetectionComponent _detectionComponent;
    private bool _moving;   
    [SerializeField]
    private float _maxJumpCooldown;
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _minimumJumpCooldown;
    [SerializeField]
    private float _jumpforce;
    private float _elapsed;
    private float _jumpTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _detectionComponent = GetComponent<EnemyDetectionComponent>();

    }

    // Update is called once per frame
    void Update()
    {
        _elapsed += Time.deltaTime;
        if(_elapsed > _jumpTime && _moving == false)
        {
            _elapsed = 0;
            _jumpTime = Random.Range(_minimumJumpCooldown, _maxJumpCooldown + 1);
            if(transform.localScale.x >= 0)
            _rigidbody2D.AddForce(Vector2.up * _jumpforce * 1.5f + Vector2.left * _jumpforce, ForceMode2D.Impulse);
            else if(transform.localScale.x < 0)
            _rigidbody2D.AddForce(Vector2.up * _jumpforce * 1.5f + Vector2.right * _jumpforce, ForceMode2D.Impulse);
        }
        _animator.SetBool("isMoving", _moving);
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        _moving = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _moving = false;
    }

}
