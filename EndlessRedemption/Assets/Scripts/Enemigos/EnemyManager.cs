using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region references
    private Transform _playerTransform;
    private EnemyDetectionComponent _myEnemyDetection;
    private LateralMovement _myLateralMovement;
    private Rigidbody2D _myRigidbody2D;
    private CameraComponent _cameraComponent;
    private Animator _animator;
    private SmokeBomb _mySmokeBomb;

    static private EnemyManager _instance;
    static public EnemyManager Instance { get { return _instance; } }
    #endregion

    #region properties
    [SerializeField]
    public float _detectionDistance = 5f; //Distancia a la que detecta al jugador
    public float _appearingDistance; //Distancia a la que aparece del suelo
    private bool aparecido = false;  //Para que solo aparezca una vez
    public bool _onAppearing = false;
    public bool _lookingRight = true;
    private float _elapsedTime = 0f;
    private float _appearingTime = 1f;
    #endregion

    #region methods 

    public void HitAnimation()
    {
        _animator.SetTrigger("Hit");
    }
    public void Girar()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
 
    public void Appearing()
    {
        _onAppearing = true;
        _animator.SetBool("Appearing", _onAppearing);
    }

    public void EndOfAppearing()
    {
        _onAppearing = false;
        _animator.SetBool("Appearing", _onAppearing);
    }
    #endregion

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _myEnemyDetection = GetComponent<EnemyDetectionComponent>();
        _myRigidbody2D= GetComponent<Rigidbody2D>();
        _cameraComponent = PlayerManager.Instance._cameraComponent;
        _myLateralMovement = GetComponent<LateralMovement>();
        _mySmokeBomb = FindObjectOfType<SmokeBomb>();
        _myEnemyDetection.enabled = false;
        _myLateralMovement.enabled = false;
        _playerTransform = PlayerManager.Instance.transform;
        if (GetComponent<BabyDragonComponent>() == null && !GetComponent<Soldier>())
        {
            GetComponent<Renderer>().enabled = false;
        }
        else aparecido = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<BabyDragonComponent>() || !GetComponent<SpiderBehaviour>())
        {
            if (Mathf.Abs(_playerTransform.position.x - transform.position.x) < _appearingDistance && !aparecido)
            {
                GetComponent<Renderer>().enabled = true;
                Appearing();
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime > _appearingTime)
                {
                    EndOfAppearing();
                    aparecido = true;
                }
            }
        }
              
        if (Mathf.Abs(_playerTransform.position.x - transform.position.x) < _detectionDistance && aparecido && _mySmokeBomb._playerTarget)
        {
            _myLateralMovement.enabled = false;
            _myEnemyDetection.enabled = true;
        }
        else if (Mathf.Abs(_playerTransform.position.x - transform.position.x) > _detectionDistance && aparecido && _mySmokeBomb._playerTarget)
        {
            _myEnemyDetection.enabled = false;
            _myLateralMovement.enabled = true;
        }
        else if (!_mySmokeBomb._playerTarget)
        {
            _myLateralMovement.enabled = false;
            _myEnemyDetection.enabled = true;
        }

        if (PauseMenu.Instance._isPaused)
        {
            _myLateralMovement.enabled = false;
            _myEnemyDetection.enabled = false;
        }
    }
}
