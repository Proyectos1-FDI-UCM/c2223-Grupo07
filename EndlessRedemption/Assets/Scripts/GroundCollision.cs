using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    [SerializeField]
    private MovementComponent _movementComponent;
    [SerializeField]
    private GameObject _suelo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 7)
        {
            Instantiate(_suelo, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!(collision.gameObject.GetComponent<WindComponent>() && !collision.gameObject.GetComponent<EnemyLifeComponent>()))
        {
            _movementComponent._onGround = true;
            _movementComponent._jumps = 0;
        }
       
        
    }
     private void OnTriggerExit2D(Collider2D collision)
    {
        _movementComponent._onGround = false;
    }
}
