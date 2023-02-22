using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    #region references
    private CameraComponent _cameraComponent;
   
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {

       
        _cameraComponent = PlayerManager.Instance._cameraComponent; 
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.vidasPlayer <= 0)
        {
            
            Debug.Log("Vidas perdidas");
            _cameraComponent.enabled = false;
            
            Destroy(gameObject);
        }
    }
}
