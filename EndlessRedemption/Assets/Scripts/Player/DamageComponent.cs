using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DamageComponent : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _hitExplosion;
    [SerializeField]
    private GameObject _UpExplosion;
    [SerializeField]
    private GameObject _DownExplosion;
    private AttackComponent _attack;
    private Transform _myTransform;
    private EnemyLifeComponent _enemyLife;
    public AudioSource _clip;
    #endregion

    #region properties
    private Vector2 _empuje;
    public float _fuerza;
    public int _damage;
    public float _elapsedTime = 0.1f;
    private float _time = 0f;
    public bool _downAttack = false;
    public bool _upAttack = false;
    #endregion


    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.gameObject.GetComponent<EnemyLifeComponent>())
        {
            _enemyLife = collision.gameObject.GetComponent<EnemyLifeComponent>();
            if(!_downAttack&&!_upAttack)
            {
                Instantiate(_hitExplosion, _enemyLife.transform.position, Quaternion.identity);
            }
            _enemyLife.vidasEnemy = _enemyLife.vidasEnemy - _damage;
            if(PlayerPrefs.GetInt("SmokeHits") < 5)
            PlayerPrefs.SetInt("SmokeHits", PlayerPrefs.GetInt("SmokeHits") + _damage);
            if (collision.gameObject.GetComponent<EnemyLifeComponent>())//Empuje
            {
                _empuje = new Vector3(collision.gameObject.transform.position.x - _myTransform.position.x, collision.gameObject.transform.position.y - _myTransform.position.y);
                _empuje.Normalize();
                if(collision.gameObject.GetComponent<EnemyManager>())
                collision.gameObject.GetComponent<EnemyManager>().HitAnimation();
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(_empuje * _fuerza, ForceMode2D.Impulse);
            }
            
            if (_downAttack)//Empuje al jugador
            {
                Instantiate(_DownExplosion, _enemyLife.transform.position, Quaternion.identity);
                gameObject.GetComponentInParent<MovementComponent>().Up();
                _downAttack = false;
            }else if (_upAttack)
            {
                Instantiate(_UpExplosion, _enemyLife.transform.position, Quaternion.identity);
            }
            

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
