using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FakeTiles : MonoBehaviour
{
    public float _timeToDestroy = 1f; //tiempo que tarda en destruirse
    private float _time = 0f;
    public GameObject rompible; //prefab de la plataforma rompible
    private bool _destroyed = false;
    private SoundManager _soundManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerManager>())
        {
           // Instantiate(rompible, transform.position, Quaternion.identity);
            _destroyed = true;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_destroyed)
        {
            _time += Time.deltaTime;
            if (_time >= _timeToDestroy)
            {
                Instantiate(rompible, transform.position, Quaternion.identity);
                Destroy(gameObject);
                _time = 0f;
                _soundManager.SeleccionAudio(7, 0.5f);
            }  
        }
    }

    
}
