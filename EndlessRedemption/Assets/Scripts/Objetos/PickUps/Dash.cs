using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField]
    private GameObject dashUI;

    #region methods
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerManager>())//Si lo coge el jugador solo, para que no triggeree con elementos de la escena
        {
            collider.gameObject.GetComponent<MovementComponent>()._dashPickUp = true;
            PlayerPrefs.SetInt("hasDash", 1);
            UIManager.Instance.ShowDashIcon();
            collider.gameObject.GetComponent<PowerUps>().enabled = true;
            collider.gameObject.GetComponent<PowerUps>()._dJump = false;
            collider.gameObject.GetComponent<PowerUps>()._dash = true;
            collider.gameObject.GetComponent<PowerUps>()._objetive = transform;
            Destroy(gameObject);
            Debug.Log("Dash recogido");
        }
    }
    #endregion
}
