using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCinematica : MonoBehaviour
{
    private float _elapsedTime = 0;
    [SerializeField]
    private float _timeStill;
    private bool _desactivateInput = true;
    private MovementComponent _movementComponent;
    // Start is called before the first frame update
    void Start()
    {
        _movementComponent = PlayerManager.Instance.GetComponent<MovementComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime > _timeStill )
        {
            
            _movementComponent.Right();
        }
        if(_elapsedTime > 0.05 && _desactivateInput)
        {
            _desactivateInput = false;
            PlayerManager.Instance.GetComponent<InputComponent>().enabled = false;
        }
    }
}
