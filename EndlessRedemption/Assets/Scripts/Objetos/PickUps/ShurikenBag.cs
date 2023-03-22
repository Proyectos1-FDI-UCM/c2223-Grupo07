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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
