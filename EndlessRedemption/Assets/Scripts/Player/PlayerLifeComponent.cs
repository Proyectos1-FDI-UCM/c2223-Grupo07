using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    public int vidasPlayer = 3;
    private Collider2D _myCollider2D;
    [SerializeField] 
    private Camera _camera;
    private CameraComponent _cameraComponent;

    #region methods
 

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myCollider2D = GetComponent<Collider2D>();
        _cameraComponent = _camera.GetComponent<CameraComponent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (vidasPlayer <= 0)
        {
            Debug.Log("Franco");
            _cameraComponent.enabled = false;
            Destroy(gameObject);
        }
    }
}
