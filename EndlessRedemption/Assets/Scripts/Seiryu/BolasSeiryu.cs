using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasSeiryu : MonoBehaviour
{
    #region refernces
    [SerializeField]
    private GameObject _bolaDeFuego;
    private GameObject _bolaDeFuego2;
    private GameObject _bolaDeFuego3;
    #endregion

    #region parameters
    [SerializeField]
    private float _bolaDeFuegoSpeed = 6f;
    #endregion

    public void BolasHorizontales()
    {
        GameObject bolaDeFuego2 = Instantiate(_bolaDeFuego, transform.position, Quaternion.identity);
        bolaDeFuego2.GetComponent<Rigidbody2D>().velocity = Vector3.right * _bolaDeFuegoSpeed;
        GameObject bolaDeFuego3 = Instantiate(_bolaDeFuego, transform.position, Quaternion.identity);
        bolaDeFuego3.GetComponent<Rigidbody2D>().velocity = Vector3.left * _bolaDeFuegoSpeed;
        _bolaDeFuego2 = bolaDeFuego2;
        _bolaDeFuego3 = bolaDeFuego3;
    }
    public void BolasDiagonales()
    {
        Destroy(_bolaDeFuego2);
        Destroy(_bolaDeFuego3);
        GameObject bolaDeFuego4 = Instantiate(_bolaDeFuego, _bolaDeFuego2.transform.position, Quaternion.identity);
        bolaDeFuego4.GetComponent<Rigidbody2D>().velocity = Vector3.one * _bolaDeFuegoSpeed;
        GameObject bolaDeFuego5 = Instantiate(_bolaDeFuego, _bolaDeFuego2.transform.position, Quaternion.identity);
        bolaDeFuego5.GetComponent<Rigidbody2D>().velocity = -Vector3.one * _bolaDeFuegoSpeed;
        GameObject bolaDeFuego6 = Instantiate(_bolaDeFuego, _bolaDeFuego2.transform.position, Quaternion.identity);
        bolaDeFuego6.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * _bolaDeFuegoSpeed;
        GameObject bolaDeFuego7 = Instantiate(_bolaDeFuego, _bolaDeFuego2.transform.position, Quaternion.identity);
        bolaDeFuego7.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * _bolaDeFuegoSpeed;
        GameObject bolaDeFuego8 = Instantiate(_bolaDeFuego, _bolaDeFuego3.transform.position, Quaternion.identity);
        bolaDeFuego8.GetComponent<Rigidbody2D>().velocity = Vector3.one * _bolaDeFuegoSpeed;
        GameObject bolaDeFuego9 = Instantiate(_bolaDeFuego, _bolaDeFuego3.transform.position, Quaternion.identity);
        bolaDeFuego9.GetComponent<Rigidbody2D>().velocity = -Vector3.one * _bolaDeFuegoSpeed;
        GameObject bolaDeFuego10 = Instantiate(_bolaDeFuego, _bolaDeFuego3.transform.position, Quaternion.identity);
        bolaDeFuego10.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * _bolaDeFuegoSpeed;
        GameObject bolaDeFuego11 = Instantiate(_bolaDeFuego, _bolaDeFuego3.transform.position, Quaternion.identity);
        bolaDeFuego11.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * _bolaDeFuegoSpeed;
    }
}
