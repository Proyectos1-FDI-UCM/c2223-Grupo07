using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteSeiryu : MonoBehaviour
{
    [SerializeField]
    private GameObject _camera;
    [SerializeField] private GameObject _deadCamera;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField] private GameObject _deadrocks; 
    [SerializeField]
    private GameObject _explosion2;
    private GameObject explosion;
    private SeiryuManager _manager;
    [SerializeField]
    private Transform _centreTransform;
    [SerializeField]
    private Transform _Transform;
    [SerializeField]
    private GameObject _Roquitas;
    [SerializeField]
    private float _time;
    private float _elapsedTime=0f;
    private float _elapsedTime2 = 0f;
    [SerializeField]
    private float _velocidad;
    private Vector3 directionSeiryu;
    private bool _entra = true;
    private bool _boom = true;
    private bool _death = true;
    private bool _dead = false;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _manager = GetComponent<SeiryuManager>();
        directionSeiryu = new Vector3(0, -15,0);
        
        _deadCamera.SetActive(true);
        _camera.SetActive(false);
        _deadrocks.SetActive(true);
        PlayerManager.Instance.GetComponent<PlayerManager>().enabled = false;
       
       // MusicManager.Instance.StopMusic();
        PlayerManager.Instance.GetComponent<InputComponent>().enabled= false;
        GameManager.Instance._lifes = 100;
        
        
    }

    // Update is called once per frame
    void Update()
    {
      
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _time && _entra)
        {
            explosion = Instantiate(_explosion, transform.position+directionSeiryu, Quaternion.identity);
            _manager.enabled= false;
            _boom = true;
            _entra=false;
        }
        if (!_entra)
        {
            _elapsedTime2 += Time.deltaTime;
            if (_elapsedTime2 > 5)
            {
                
               Destroy(explosion);
                _animator.SetBool("DEATH", true);
                GetComponent<Rigidbody2D>().gravityScale = 4;
                _boom= false;
                if (_dead)
                {
                    _death = true;
                    _dead = false;
                }
                //Destroy(gameObject);
            }
            if (_death)
            {
                Instantiate(_Roquitas, _Transform.position, Quaternion.identity);
                _death= false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (_boom)
        {
            Instantiate(_explosion2, transform.position, Quaternion.identity);
        }
    }
}
