using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{

    #region methods
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerManager>()) //Si lo coge el jugador solo, para que no triggeree con elementos de la escena
        {
            GameManager.Instance.WinLife();
            Destroy(gameObject);
        }
    }
    #endregion
}
