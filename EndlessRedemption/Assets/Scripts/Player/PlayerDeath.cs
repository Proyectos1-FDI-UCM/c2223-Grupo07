using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private float _rotation = 0.5f;
    [SerializeField]
    private float _maxRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.rotation.eulerAngles.z < _maxRotation)
        {
            transform.Rotate(0, 0, _rotation);
        }
    }
}
