using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDragonComponent : MonoBehaviour
{
    private EnemyDetectionComponent _enemyDetectionComponent;
    private Animator _animator;
    private bool _direction;
    // Start is called before the first frame update
    void Start()
    {
        _direction = false;
        _animator = GetComponent<Animator>();
        _enemyDetectionComponent = GetComponent<EnemyDetectionComponent>();
    }

    // Update is called once per frame
    void Update()
    {       
        if(_direction != _enemyDetectionComponent._directionRight)
        {
            Turn();          
        }
        _animator.SetBool("Attacking", _enemyDetectionComponent._attacking);
    }
    void Turn()
    {
        _direction = !_direction;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    
}
