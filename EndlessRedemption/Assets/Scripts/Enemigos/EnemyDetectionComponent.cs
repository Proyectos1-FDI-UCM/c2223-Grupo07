using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionComponent : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 1f;
    [SerializeField]
    private float _detectionDistance = 5f;
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = PlayerManager.Instance.transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (_playerTransform.position.x - transform.position.x < _detectionDistance) {
            if (_playerTransform.position.x - transform.position.x < 0)
            {
                transform.Translate(Vector2.left * Time.deltaTime * _enemySpeed);
            }
            else transform.Translate(Vector2.right * Time.deltaTime * _enemySpeed);
        }

    }
}
