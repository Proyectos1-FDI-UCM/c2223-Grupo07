using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField]
    private GameObject djUI;//tutorial del doble salto

    #region methods
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerManager>())//Si lo coge el jugador solo, para que no triggeree con elementos de la escena
        {
            djUI.SetActive(true);
            collider.gameObject.GetComponent<MovementComponent>()._jumpsAvailable++;
            PlayerPrefs.SetInt("hasDoubleJump", 1);
            UIManager.Instance.ShowDoubleJumpIcon();
            collider.gameObject.GetComponent<PowerUps>().enabled=true;
            collider.gameObject.GetComponent<PowerUps>()._dJump = true;
            collider.gameObject.GetComponent<PowerUps>()._iniciar = true;
            collider.gameObject.GetComponent<PowerUps>()._objetive = transform;
            gameObject.SetActive(false);
            Debug.Log("Doble salto recogido");

        }
    }
    #endregion
}
