using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarFuego : MonoBehaviour
{
    [SerializeField]
    private float _time;

    private float _elapsedtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedtime += Time.deltaTime;
        if(_elapsedtime >= _time)
        {
            gameObject.SetActive(false);
        }
    }
}
