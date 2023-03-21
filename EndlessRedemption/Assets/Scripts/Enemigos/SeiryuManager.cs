using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiryuManager : MonoBehaviour
{
    //Estados
    public enum BossStates { MOLESTO, ENFADADO, FURIOSO}
    public enum AttackStates { BASICO, BOLAS, COLUMNAS, PINCHOS, EMBESTIDA}
    public enum MovementStates { HUIR, RANDOM, QUIETO}
    private BossStates _currentBossState;
    private AttackStates _currentAttackState;
    private MovementStates _currentMovementState;


    //Propiedades
    private float _bossSpeed = 1.0f;
    private int _bossLifes;
    private int _randomAttack;
    [SerializeField]
    private float _minTimeBetweenAttacks = 2f;
    [SerializeField]
    private float _maxTimeBetweenAttacks = 9f;
    private float _timeBetweenAttacks;
    private float _basicTime = 6f;
    private float _bolasTime = 6f;
    private float _columnasTime = 6f;
    private float _pinchosTime = 6f;
    private float _embestidaTime = 6f;
    private bool _isAttacking = false;
    private Vector3 _movementDirection;


    private float _elapsedTime = 0f;

    //Referencias
    private GameObject _bossUI;

    //Metodos
    public void ChooseAttack(BossStates bossState)
    {
        switch (bossState)
        {
            case BossStates.MOLESTO:
                _randomAttack = Random.Range(0, 2);
                _currentAttackState = _randomAttack;
                break;
            case BossStates.ENFADADO:
                _randomAttack = Random.Range(0, 4);
                _currentAttackState = _randomAttack;
                break;
            case BossStates.FURIOSO:
                _randomAttack = Random.Range(0, 5);
                _currentAttackState = _randomAttack;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentMovementState = MovementStates.QUIETO;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_currentBossState)
        {
            case BossStates.MOLESTO:                
                _bossSpeed = 1.0f;
                break;
            case BossStates.ENFADADO:

                break;
            case BossStates.FURIOSO:

                break;
        }

        switch(_currentMovementState)
        {
            case MovementStates.QUIETO:

                break;
            case MovementStates.RANDOM:

                break;
            case MovementStates.HUIR:

                break;
        }

        if (_isAttacking)
        {
            switch (_currentAttackState)
            {
                case AttackStates.BASICO:

                    break;
                case AttackStates.BOLAS:

                    break;
                case AttackStates.COLUMNAS:

                    break;
                case AttackStates.PINCHOS:

                    break;
                case AttackStates.EMBESTIDA:

                    break;
            }

        }
    }
}
