 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollider : MonoBehaviour
{
    private MovementComponent _movementComponent;
    private Collider2D _collider2D;
    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _movementComponent = GetComponentInParent<MovementComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_movementComponent._dashing)
            _collider2D.enabled = false;
        else _collider2D.enabled = true;
    }
}
