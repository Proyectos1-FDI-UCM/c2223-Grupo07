using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralMovement : MonoBehaviour
{
    private enum IslandState {STOP , MOVING}
    private IslandState _islandState;
    private EnemyManager _enemyManager;
    [SerializeField]
    float _movementSpeed;
    [SerializeField]
    float _timeMoving;
    [SerializeField]
    float _timeStill;//How many time will it stay still until changing direction
    private float _elapsedTime;
    [SerializeField]
    bool _verticalMove;
    

    // Start is called before the first frame update
    
    void Start()
    {
        _islandState = IslandState.MOVING;
        _enemyManager = GetComponent<EnemyManager>();
        _elapsedTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;
        if (_islandState == IslandState.MOVING && _elapsedTime > _timeMoving)
        {
            _elapsedTime= 0;

            
            ChangeState(IslandState.STOP);
            
        }
        else if(_islandState == IslandState.STOP && _elapsedTime > _timeStill)
        {
            _elapsedTime= 0;

            
            ChangeState(IslandState.MOVING);
            _movementSpeed *= -1;
        }
        if(_islandState == IslandState.MOVING)
        {
             Move();
            
        }
        
    }
    private void Move()
    {
        if (_verticalMove)
        {
            transform.position += new Vector3(0, _movementSpeed * Time.deltaTime);
        }
        else
        {
            if(GetComponent<EnemyManager>() != null) 
            {
                if (_movementSpeed > 0 && transform.localScale.x > 0)
                {
                    _enemyManager.Girar();
                }
                if (_movementSpeed < 0 && transform.localScale.x < 0)
                {
                    _enemyManager.Girar();
                }
            }
           

            transform.position += new Vector3(_movementSpeed * Time.deltaTime, 0);
         
        }
    }
    private void ChangeState(IslandState newState) 
    { 
         _islandState = newState;
    }
}