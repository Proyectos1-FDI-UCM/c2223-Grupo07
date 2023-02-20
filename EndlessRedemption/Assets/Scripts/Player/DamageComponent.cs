using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    #region references
    private AttackComponent _attack;
    private Transform _myTransform;
    private EnemyLifeComponent _enemyLife;
    #endregion

    #region properties
    private Vector2 _empuje;
    public float _fuerza;
    public int _damage;
    public float _elapsedTime = 0.00000000001f;
    private float _time = 0f;
    #endregion


    #region methods
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            _enemyLife = collision.gameObject.GetComponent<EnemyLifeComponent>();
            _enemyLife.vidasEnemy =_enemyLife.vidasEnemy - _damage;
            _empuje = new Vector2(collision.gameObject.transform.position.x - _myTransform.position.x, collision.gameObject.transform.position.y - _myTransform.position.y);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce( _empuje*_fuerza, ForceMode2D.Impulse);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _attack = GetComponentInParent<AttackComponent>();
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_time > _elapsedTime )
        {
            _attack.EndOfAttack();
            Destroy(gameObject);
        }
    
    }
}
