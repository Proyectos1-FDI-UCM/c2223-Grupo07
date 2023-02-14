using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashDetection : MonoBehaviour
{
    [SerializeField]
    private float _dashScope;
    [SerializeField]
    private MovementComponent _movementComponent;
    [SerializeField]
    private Transform _playerTransform;
    private Vector3 _myPosition;
    public Vector3 PositionToReach {
        get{ return _myPosition; } }
    private void OnTriggerStay2D(Collider2D collision)
    {
        _movementComponent._dashAvailable = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!_movementComponent._dashing)
        {
            _movementComponent._dashAvailable = true;
        }
              
    }    
    private void LateUpdate()
    {
        _myPosition = transform.position;
        transform.position = _playerTransform.position + new Vector3(_dashScope, 0);
    }
    public void DashDirection()
    {
        _dashScope *= -1;
    }

}
