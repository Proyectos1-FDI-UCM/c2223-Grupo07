using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRampa : MonoBehaviour
{
    private MovementComponent _myMovementComponent;
    // Start is called before the first frame update
    void Start()
    {
        _myMovementComponent = GetComponent<MovementComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _myMovementComponent.Jump();
        }
    }
}
