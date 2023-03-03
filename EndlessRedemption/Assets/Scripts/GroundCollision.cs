using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    [SerializeField]
    private MovementComponent _movementComponent;
    

    private void OnTriggerStay2D(Collider2D collision)
    {      
        _movementComponent._onGround = true;
        _movementComponent._jumps= 0;
        
    }
     private void OnTriggerExit2D(Collider2D collision)
    {
        _movementComponent._onGround = false;
    }
}
