using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShuriken : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _rotationAngle;
    [SerializeField]
    private float _force;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        float randomx = Random.Range(-2, 2);
        float randomy = Random.Range(-2, 2);
        
        _rigidbody2D.AddForce(new Vector2(randomx, randomy) * _force);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * _rotationAngle);
    }
}
