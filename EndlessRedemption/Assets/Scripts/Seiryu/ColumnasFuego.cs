using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnasFuego : MonoBehaviour
{
    private bool _bolFuego = false;

    [SerializeField]
    private GameObject _fuego;

    [SerializeField]
    private Transform _fuego1;
    [SerializeField]
    private Transform _fuego2;
    [SerializeField]
    private Transform _fuego3;
    [SerializeField]
    private Transform _fuego4;
    [SerializeField]
    private Transform _fuego5;

    public void Invocar()
    {
        Instantiate(_fuego, _fuego1.position, Quaternion.identity);
        Instantiate(_fuego, _fuego2.position, Quaternion.identity);
        Instantiate(_fuego, _fuego3.position, Quaternion.identity);
        Instantiate(_fuego, _fuego4.position, Quaternion.identity);
        Instantiate(_fuego, _fuego5.position, Quaternion.identity);
        _bolFuego = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_bolFuego)
        {
            this.enabled = true;
        }
    }
}
