using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    #region references
    private Transform _playerTransform;
    private EnemyDetectionComponent _myEnemyDetection;
    private LateralMovement _myLateralMovement;
    private CameraComponent _cameraComponent;
    private Animator _animator;

    static private EnemyManager _instance;
    static public EnemyManager Instance { get { return _instance; } }
    #endregion

    #region properties
    [SerializeField]
    public float _detectionDistance = 5f; //Distancia a la que detecta al jugador
    public float _appearingDistance; //Distancia a la que aparece del suelo
    private int aparecido = 0;  //Para que solo aparezca una vez
    public bool _onAppearing = false;
    private float _elapsedTime = 0f;
    private float _appearingTime = 1f;
    #endregion

    #region methods 

    public void Appearing()
    {
        _onAppearing=true;
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
        _myEnemyDetection = GetComponent<EnemyDetectionComponent>();
        _cameraComponent = PlayerManager.Instance._cameraComponent;
        _myLateralMovement = GetComponent<LateralMovement>();
        _myEnemyDetection.enabled = false;
        _myLateralMovement.enabled = false;
        _playerTransform = PlayerManager.Instance.transform;
        GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(_playerTransform.position.x - transform.position.x) < _appearingDistance && Mathf.Abs(_playerTransform.position.x - transform.position.x) > _detectionDistance)
        {
            GetComponent<Renderer>().enabled = true;
            Appearing();
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _appearingTime)
            {
                EndOfAppearing();
            }
            _myLateralMovement.enabled = true;
            aparecido++;
        }
        if (Mathf.Abs(_playerTransform.position.x - transform.position.x) < _detectionDistance)
        {
            _myEnemyDetection.enabled = true;
        }else _myEnemyDetection.enabled = false;

    }
}
