using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashDamage : MonoBehaviour
{
    private MovementComponent _movementComponent;
    [SerializeField]
    private Transform _playerTransform;   
    private float _dashDamagePosition;
    private EnemyLifeComponent _enemyLife;
    private Vector2 _empuje;
    public float _fuerzaEmpuje;
    public int _damage;
    // Start is called before the first frame update
    void Start()
    {
        _dashDamagePosition = 0.5f;
        _movementComponent = FindObjectOfType<MovementComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_movementComponent._dashing)
        {
            if(other.gameObject.tag == "Enemigo")
            {
                _enemyLife = other.gameObject.GetComponent<EnemyLifeComponent>();
                _enemyLife.vidasEnemy = _enemyLife.vidasEnemy - _damage;
                _empuje = new Vector2(other.gameObject.transform.position.x - _playerTransform.position.x, other.gameObject.transform.position.y - _playerTransform.position.y);
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(_empuje * _fuerzaEmpuje, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_movementComponent._dashing && !_movementComponent._dashAvailable)
        {
            _movementComponent._dashing = false;//aregla el bug de la animacion
            _movementComponent._dashAvailable = true;
        }
        //Para hacer el daño necesito enemigo primero
        
    }
    private void LateUpdate()
    {      
        transform.position = _playerTransform.position + new Vector3(_dashDamagePosition, 0);
    }
    public void DamageDirection()
    {
        _dashDamagePosition *= -1;
    }
}
