using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteVacio : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision) //Matar entidad
	{
        if (collision.gameObject.GetComponent<PlayerManager>())
        {
			GameManager.Instance.Muerte();
		}
        else if (collision.gameObject.GetComponent<EnemyLifeComponent>())
        {
			collision.gameObject.GetComponent<EnemyLifeComponent>().Muerte();

		}


	}
}
