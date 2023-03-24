using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasColumnas : MonoBehaviour
{
    private Vector3 _trayectoria;

    [SerializeField]
    private float _Speed;

    [SerializeField]
    private GameObject _columna;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(_columna, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        _trayectoria = transform.position - SeiryuManager.Instance._trayec.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_trayectoria*Time.deltaTime*_Speed);
    }
}
