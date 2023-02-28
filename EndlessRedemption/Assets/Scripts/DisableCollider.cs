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
    }

    // Update is called once per frame
    
    public void Collider()
    {
        _collider2D.enabled = false;
    }
    public void ColliderEnable()
    {
        _collider2D.enabled = true;
    }
}
