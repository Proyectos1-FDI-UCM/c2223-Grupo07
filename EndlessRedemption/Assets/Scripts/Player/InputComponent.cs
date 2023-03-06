using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    #region references
    private MovementComponent _movementComponent;
    private SmokeBomb _smokeBomb;
    private AttackComponent _attack;
    private ShurikenLauncher _shurikenLauncher;
    private PauseMenu _PauseMenu;
    [SerializeField]
    private GameObject PauseMenuObject;
    #endregion


    void Start()
    {
        _movementComponent = GetComponent<MovementComponent>();
        _smokeBomb = GetComponent<SmokeBomb>();
        _attack = GetComponentInChildren<AttackComponent>();
        _shurikenLauncher = GetComponent<ShurikenLauncher>();
        _PauseMenu = PauseMenuObject.GetComponent<PauseMenu>();
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
        else if (Input.GetKey(KeyCode.A))
        {
            _movementComponent.Left();

        }
        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _movementComponent.Dash();
        }
        //Bomba humo
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _smokeBomb.ActivateSmoke();
        }
        //Ataque
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _attack.HorizontalAttack();
          
            
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _attack.UpAttack();


        }
         else if (Input.GetKeyDown(KeyCode.S))
        {
            _attack.DownAttack();
        }
       //Lanzamiento shuriken
        if(Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Mouse1))
        {
            _shurikenLauncher.UpThrow();
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Mouse1))
        {
            _shurikenLauncher.DownThrow();
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            _shurikenLauncher.LateralThrow();
        }
        //Pausa
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (PauseMenu.isPaused) _PauseMenu.ResumeGame(PauseMenuObject);
            else _PauseMenu.PauseGame(PauseMenuObject);
        }
    }
}
