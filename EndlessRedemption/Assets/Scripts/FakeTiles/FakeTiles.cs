using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTiles : MonoBehaviour
{
    public float _timeToDestroy = 1f; //tiempo que tarda en destruirse
    public float _time = 0f;
    //public GameObject rompible; //prefab de la plataforma rompible
    private bool _destroyed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // Instantiate(rompible, transform.position, Quaternion.identity);
            _destroyed = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_destroyed)
        {
            _time += Time.deltaTime;
            if (_time >= _timeToDestroy)
            {
                Destroy(gameObject);
                _time = 0f;
            }  
        }
    }

    
}
