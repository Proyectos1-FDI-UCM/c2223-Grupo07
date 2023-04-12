using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaInput : MonoBehaviour
{
    private InputComponent _myInputComponent;
    [SerializeField]
    private GameObject PauseMenuObject;
    private PauseMenu _PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        _PauseMenu = PauseMenuObject.GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Options"))
        {
            if (_PauseMenu._isPaused)
            {
                _PauseMenu.ResumeGame(PauseMenuObject);
            }
        }
    }
}
