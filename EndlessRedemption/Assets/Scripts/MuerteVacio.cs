using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteVacio : MonoBehaviour
{
	// Start is called before the first frame update
	private void OnTriggerEnter2D(Collider2D collision)
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
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
