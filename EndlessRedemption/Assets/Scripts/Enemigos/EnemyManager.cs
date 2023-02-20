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

    static private EnemyManager _instance;
    static public EnemyManager Instance { get { return _instance; } }
    #endregion

    #region properties
    [SerializeField]
    public float _detectionDistance = 5f; //Distancia a la que detecta al jugador
    public float _appearingDistance; //Distancia a la que aparece del suelo
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
