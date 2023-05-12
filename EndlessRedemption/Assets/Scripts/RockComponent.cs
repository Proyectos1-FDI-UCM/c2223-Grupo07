using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockComponent : MonoBehaviour
{
    [SerializeField]
    private float _distance;
    [SerializeField]
    private float _velocity;
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    [SerializeField]
    private GameObject _rock;
    private bool _falling = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_rigidbody2D.gravityScale > 0)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(_transform.position.x - PlayerManager.Instance.transform.position.x)<= _distance && !_falling && Mathf.Abs(_transform.position.y - PlayerManager.Instance.transform.position.y)<= 10 )
        {
            Instantiate(_rock, transform.position, Quaternion.identity);
            _rigidbody2D.gravityScale = _velocity;
            if(!_falling)
            {
                SoundManager.Instance.SeleccionAudio(21, 1f);
            }
            _falling = true;

        }
    }
}
