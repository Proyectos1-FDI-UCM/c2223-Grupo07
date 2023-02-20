using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    #region references
    private MovementComponent _movementComponent;
    private SmokeBomb _smokeBomb;
    private AttackComponent _attack;
    
    #endregion


    void Start()
    {
        _movementComponent = GetComponent<MovementComponent>();
        _smokeBomb = GetComponent<SmokeBomb>();
        _attack = GetComponentInChildren<AttackComponent>();
       
    }

    void Update()
    {
        // Sistema de salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movementComponent.Jump();
        }


        // Sistema de movimiento
        if (Input.GetKey(KeyCode.D))
        {
            _movementComponent.Right();

        }
        if (Input.GetKey(KeyCode.A))
        {
            _movementComponent.Left();

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _movementComponent.Dash();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _smokeBomb.ActivateSmoke();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _attack.HorizontalAttack();
          
            
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _attack.UpAttack();


        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _attack.DownAttack();


        }


    }
}
