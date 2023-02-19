using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    private Collider2D _myCollider2D;
    [SerializeField] 
    private Camera _camera;
    private CameraComponent _cameraComponent;

    private Transform _myTransform;
    private Vector2 _empuje;
    private float _fuerza;
    private Rigidbody2D _rb2D;

    #region methods
    public void HitKnockBack(GameObject _enemy)
    {
        _empuje = new Vector2(_myTransform.position.x - _enemy.transform.position.x, _myTransform.position.y - _enemy.transform.position.y);
        _rb2D.AddForce(_empuje * _fuerza, ForceMode2D.Impulse);
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myCollider2D = GetComponent<Collider2D>();
        _cameraComponent = _camera.GetComponent<CameraComponent>(); 
        _myTransform = transform;
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.vidasPlayer <= 0)
        {
            Debug.Log("Franco");
            _cameraComponent.enabled = false;
            Destroy(gameObject);
        }
    }
}
