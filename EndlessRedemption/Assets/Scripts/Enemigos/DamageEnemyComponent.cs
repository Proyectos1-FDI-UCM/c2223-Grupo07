using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DamageEnemyComponent : MonoBehaviour
{
    
    #region properties
    public int _damage;
    #endregion
    #region methods

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>())
        {
           
            PlayerManager.Instance.vidasPlayer-=_damage; //Dañar al player si choca con el
            PlayerManager.Instance.Invulnerable(2.0f); //Player se vuelve invulnerable durante dos segundos
            Debug.Log("Vidas: " + PlayerManager.Instance.vidasPlayer);
            GameManager.Instance.LoseLife();
        }
    }
    #endregion
}
