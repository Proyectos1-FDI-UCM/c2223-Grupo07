using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenComponent : MonoBehaviour
{
    private EnemyLifeComponent _enemyLifeComponent;
    private Rigidbody2D _rigidbody2D;
    private ShurikenLauncher _shurikenLauncher;
    [SerializeField]
    private float _shurikenSpeed;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _rotationAngle;
    private bool _vertical;
    [SerializeField]
    private bool _turn;
    
    // Start is called before the first frame update
    void Start()
    {
        _shurikenLauncher = FindObjectOfType<ShurikenLauncher>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if(_shurikenLauncher._expectedDirection == ShurikenLauncher.Direction.RIGHT) { _vertical = false; }
        else if(_shurikenLauncher._expectedDirection == ShurikenLauncher.Direction.LEFT) { _shurikenSpeed *= -1; _vertical = false; }
        else if(_shurikenLauncher._expectedDirection == ShurikenLauncher.Direction.UP) { _vertical = true; }
        else if(_shurikenLauncher._expectedDirection == ShurikenLauncher.Direction.DOWN) { _shurikenSpeed *= -1; _vertical = true; }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_vertical)
        {
            _rigidbody2D.velocity = new Vector2(_shurikenSpeed, 0);
        }
        else _rigidbody2D.velocity = new Vector2(0, _shurikenSpeed);

        if(_turn)
        {
            transform.RotateAround(Vector3.forward, _rotationAngle);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {      
        if (collision.collider.GetComponent<EnemyLifeComponent>() != null)
        {
            collision.collider.GetComponent<EnemyLifeComponent>().vidasEnemy -=_damage;
        }
        Destroy(gameObject);      
    }
}
