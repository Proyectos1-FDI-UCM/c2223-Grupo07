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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            _movementComponent.Jump();
        }
        // Sistema de movimiento
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("StickHorizontal") >= 0.7)
        {
            _movementComponent.Right();

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetAxis("StickHorizontal") <= -0.7)
        {
            _movementComponent.Left();
        }
        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("R2"))
        {
            _movementComponent.Dash();
        }
        //Bomba humo
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Triangle"))
        {
            _smokeBomb.ActivateSmoke();
        }
        //Ataque
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Square"))
        {
            if(Input.GetAxis("StickVertical") >=0.5)
            {
                _attack.UpAttack();
            }
            else if(Input.GetAxis("StickVertical") <= -0.5)
            {
                _attack.DownAttack();
            }
            else
            {
                _attack.HorizontalAttack();
            }
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
        if((Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Mouse1)) || (Input.GetButtonDown("R1")&& Input.GetAxis("StickVertical") >= 0.7))
        {
            _shurikenLauncher.UpThrow();
        }
        else if ((Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Mouse1)) || (Input.GetButtonDown("R1") && Input.GetAxis("StickVertical") <= -0.7))
        {
            _shurikenLauncher.DownThrow();
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1) || Input.GetButtonDown("R1"))
        {
            _shurikenLauncher.LateralThrow();
        }
        //Pausa
      
        if(Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.SetInt("LevelX", PlayerPrefs.GetInt("LevelX") + 1);
            Debug.Log("Level:" + PlayerPrefs.GetInt("LevelX"));
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            PlayerPrefs.SetInt("CheckpointX", PlayerPrefs.GetInt("CheckpointX") + 1);
            Debug.Log("Checkpoint:" + PlayerPrefs.GetInt( "CheckpointX"));
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            PlayerPrefs.SetInt("LevelX", 1);
            Debug.Log("Level:" + PlayerPrefs.GetInt("LevelX"));
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            PlayerPrefs.SetInt("CheckpointX", 0);
            Debug.Log("Checkpoint:" + PlayerPrefs.GetInt("CheckpointX"));
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            PlayerPrefs.SetInt("hasDash", 1);
            PlayerManager.Instance.GetComponent<MovementComponent>()._dashPickUp = true;
        }
        if(Input.GetKeyDown(KeyCode.J)) 
        {
            PlayerManager.Instance.GetComponent<MovementComponent>()._jumpsAvailable++;
            PlayerPrefs.SetInt("hasDoubleJump", 1);
        }
    }
}
