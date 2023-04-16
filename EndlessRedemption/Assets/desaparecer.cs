using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparecer : MonoBehaviour
{
    private float _elapsedTime = 0;
    [SerializeField]
    private GameObject _titulo;
    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime > 3)
        {
            _titulo.SetActive(true);
            if (_elapsedTime > 7)
            {
                _titulo.SetActive(false);
            }
        }
    }
}
