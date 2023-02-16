using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMovement : MonoBehaviour
{
    private enum IslandState {STOP , MOVING}
    private IslandState _islandState;
    [SerializeField]
    float _movementSpeed;
    [SerializeField]
    float _timeMoving;
    [SerializeField]
    float _timeStill;//How many time will it stay still until changing direction
    private float _elapsedTime;
    [SerializeField]
    bool _verticalMove;
    [SerializeField]
    bool _horizontalMove;

    // Start is called before the first frame update
    void Start()
    {
        _islandState = IslandState.MOVING;
        _elapsedTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;
        if (_islandState == IslandState.MOVING && _elapsedTime < _timeMoving)
        {
            if (_verticalMove)
            {
                transform.position += new Vector3(0, _movementSpeed, 0);
            }
            else if (_horizontalMove)
            {
                transform.position += new Vector3(_movementSpeed, 0, 0);
            }
        }
        else _islandState = IslandState.STOP;
        
    }
}
