using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenBag : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerManager>() || collision.gameObject.GetComponent<DisableCollider>())
        {
            GameManager.Instance._hasShurikensBag = true;
            Destroy(gameObject);
        }
            
    }
}
