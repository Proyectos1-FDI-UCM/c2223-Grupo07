using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpTutorial : MonoBehaviour
{
    private float _elapsedTime = 0;
    private float _elapsedTime2 = 0;
    private float _doublejumpTime = 0.5f;//Para desactivarlo solo cuando haya hecho un doble salto
    private float _doublejumpAnimationTime = 10f;//Para cuando termine la animacion al cogerlo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime > _doublejumpAnimationTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _elapsedTime2 += Time.deltaTime;
                if (_elapsedTime2 < _doublejumpTime)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        gameObject.SetActive(false);
                    }
                }
                _elapsedTime2 = 0;
            }
        }
        
    }
}
