using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _spawnForce;
    private float _randomLateralForce;
    private float _elapsed;
    [SerializeField]
    private float availableTime;

    // Start is called before the first frame update
    void Start()
    {
        _collider= GetComponent<Collider2D>();      
        _rigidbody2D= GetComponent<Rigidbody2D>();
        _collider.enabled = false;
        _randomLateralForce = Random.Range(-500, 500);
        _rigidbody2D.AddForce(Vector2.up * _spawnForce);
        _rigidbody2D.AddForce(Vector2.left * _randomLateralForce);
        _elapsed = 0;
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!GetComponent<SeiryuManager>())
        {
            if ((collision.collider.GetComponent<PlayerManager>() || collision.collider.GetComponent<DisableCollider>()) && GameManager.Instance._hasShurikensBag)
            {
                GameManager.Instance.PickShuriken();
                Destroy(gameObject);
            }
        }
       
    }
    private void Update()
    {
        _elapsed += Time.deltaTime;
        if(_elapsed > availableTime) {_collider.enabled = true; }
    }
}
