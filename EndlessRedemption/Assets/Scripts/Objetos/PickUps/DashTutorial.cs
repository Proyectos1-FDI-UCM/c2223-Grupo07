using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTutorial : MonoBehaviour
{
    private float _elapsedTime = 0;
    private float _dashAnimationTime = 10f;//Para cuando termine la animacion al cogerlo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _dashAnimationTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
