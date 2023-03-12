using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosDamage : MonoBehaviour
{
    #region properties
    private int  _damage = 1;
    #endregion
    #region methods

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerManager>())
        {
            GameManager.Instance.LoseLife(); //Dañar al player si choca con el
            PlayerManager.Instance.Invulnerable(2.0f); //Player se vuelve invulnerable durante dos segundos
        }
        if (collision.gameObject.GetComponent<EnemyLifeComponent>())
        {
            collision.gameObject.GetComponent<EnemyLifeComponent>().vidasEnemy -= _damage; //Dañar a enemigo si choca con el
        }
    }
    #endregion
}
