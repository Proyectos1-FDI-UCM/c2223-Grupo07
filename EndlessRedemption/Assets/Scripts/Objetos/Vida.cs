using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    #region methods
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerManager>()) //Si lo coge el jugador solo, para que no triggeree con elementos de la escena
        {
            GameManager.Instance.WinLife();
            Destroy(gameObject);
        }
    }
    #endregion
}
