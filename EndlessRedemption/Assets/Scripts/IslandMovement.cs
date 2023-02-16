using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMovement : MonoBehaviour
{
    [SerializeField]
    float _movementSpeed;
    [SerializeField]
    float timeMoving;
    [SerializeField]
    float timeStill;//How many time will it stay still until changing direction
    private float _elapsedTime;
    [SerializeField]
    bool _verticalMove;
    [SerializeField]
    bool _horizontalMove;

    // Start is called before the first frame update
    void Start()
    {
        _elapsedTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;
    }
}
