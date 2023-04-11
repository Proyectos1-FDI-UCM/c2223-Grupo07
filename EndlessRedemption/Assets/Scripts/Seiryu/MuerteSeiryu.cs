using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteSeiryu : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;
    private GameObject explosion;
    [SerializeField]
    private Transform _centreTransform;
    [SerializeField]
    private float _time;
    private float _elapsedTime=0f;
    private float _elapsedTime2 = 0f;
    [SerializeField]
    private float _velocidad;
    private Vector3 directionSeiryu;
    private bool _entra = true;
    
    // Start is called before the first frame update
    void Start()
    {
        directionSeiryu = new Vector3(_centreTransform.position.x - transform.position.x, _centreTransform.position.y - transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(directionSeiryu * _velocidad);
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _time && _entra)
        {
            explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
            _entra=false;
        }
        if (!_entra)
        {
            _elapsedTime2 += Time.deltaTime;
            if (_elapsedTime2 > 3)
            {
                Destroy(_explosion);
                //Destroy(gameObject);
            }
        }
    }
}
