using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionComponent : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 1f;
    public bool _attacking;
    public bool _directionRight;
    private Transform _playerTransform;
    private Vector2 _vectorDirection;
    private EnemyManager _enemyManager;
    private SmokeBomb _mySmokeBomb;

    private void Start()
    {
        _directionRight = false;
        _attacking = false;
        _playerTransform = PlayerManager.Instance.transform;
        _enemyManager = GetComponent<EnemyManager>(); 
        _mySmokeBomb = FindObjectOfType<SmokeBomb>();
    }
    // Update is called once per frame
    void Update()
    {
        if(_playerTransform != null && _mySmokeBomb._playerTarget)
        {
            _vectorDirection = _playerTransform.position - transform.position;
            _vectorDirection.Normalize();
            if (Mathf.Abs(_playerTransform.position.x - transform.position.x) < EnemyManager.Instance._detectionDistance)
            {
                GetComponent<LateralMovement>().enabled = false;
                _attacking = true;
                transform.Translate(_vectorDirection * Time.fixedDeltaTime * _enemySpeed);
            }
            else
            {
                _attacking = false;
            }
            if (_vectorDirection.x > 0&& transform.localScale.x>0)
            {
                _enemyManager.Girar();            }
            if (_vectorDirection.x < 0 && transform.localScale.x < 0)
            {
                _enemyManager.Girar();
            }
        }
        else if(!_mySmokeBomb._playerTarget)
        {
            _vectorDirection = _mySmokeBomb._smokePosition - transform.position;
            _vectorDirection.Normalize();
            transform.Translate(_vectorDirection * Time.fixedDeltaTime * _enemySpeed);
            if (_vectorDirection.x > 0 && transform.localScale.x > 0)
            {
                _enemyManager.Girar();
            }
            if (_vectorDirection.x < 0 && transform.localScale.x < 0)
            {
                _enemyManager.Girar();
            }
        }
    }
}
