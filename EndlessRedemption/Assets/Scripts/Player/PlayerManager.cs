using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region references
    private Animator _animator;
    private Transform _myTransform;
    private int _myLayer;
    private Rigidbody2D _rb2D;
    static private PlayerManager _instance;
    static public PlayerManager Instance { get { return _instance; } }
    [SerializeField]
    private Camera _camera;
    public CameraComponent _cameraComponent;
  
    #endregion

    #region properties
    private Vector2 _empuje;
    public float _fuerza;
    public float _elapsedTime;
    public float _timeInvulnerable;
    private bool _invulnerable = false;
    #endregion

    #region methods

    public void Invulnerable(float timeInvulnerable)
    {
        _invulnerable = true;
        _timeInvulnerable = timeInvulnerable;
    }

    public void HitKnockBack(GameObject _enemy)
    {
        _empuje = new Vector2(_myTransform.position.x - _enemy.transform.position.x, _myTransform.position.y - _enemy.transform.position.y);
        _rb2D.AddForce(_empuje * _fuerza, ForceMode2D.Impulse);
    }
    #endregion

    void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _myTransform= transform;
        _animator = GetComponent<Animator>();
        _myLayer = gameObject.layer;
        _rb2D = GetComponent<Rigidbody2D>();
        _cameraComponent = _camera.GetComponent<CameraComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("Smoke", _invulnerable); //Animación se hará en función de la variable invulnerable
        if (_invulnerable)
        {
           
            gameObject.layer = 8; //Layer en la que no colisionan Player y Enemigo
            _elapsedTime += Time.deltaTime;
            if(_elapsedTime > _timeInvulnerable)
            {
                
                gameObject.layer = _myLayer; //Devolver layer anterior
                _invulnerable = false;
                _elapsedTime = 0;
            }
        }
    }
}
