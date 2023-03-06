using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trayectoria : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _attackingSpeed;
    public Vector3 _vectorDirection;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _vectorDirection = PlayerManager.Instance.transform.position - transform.position;
        _vectorDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(_vectorDirection * Time.fixedDeltaTime * _attackingSpeed);
    }
}
