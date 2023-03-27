using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTutorial : MonoBehaviour
{
    private float _elapsedTime = 0;
    private float _dashAnimationTime = 10f;//Para cuando termine la animacion al cogerlo

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _dashAnimationTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("R2"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
