using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaInput : MonoBehaviour
{  
    private bool _isPaused = false;
 
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Options"))
        {
            
            if (!_isPaused)
            {
                PauseMenu.Instance.PauseGame();
            }
            else PauseMenu.Instance.ResumeGame();
            _isPaused = !_isPaused;
        }
    }
}
