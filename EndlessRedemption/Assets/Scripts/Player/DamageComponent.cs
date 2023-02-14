using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    // Start is called before the first frame update
    private AttackComponent _attack;
    public float _elapsedTime = 0.0001f;
    private float _time = 0f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {

            Destroy(collision.gameObject);
            
        }
    }
   

    void Start()
    {
        _attack = GetComponentInParent<AttackComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_time> _elapsedTime )
        {
            _attack.EndOfAttack();
            Destroy(gameObject);
        }
    
    }
}
