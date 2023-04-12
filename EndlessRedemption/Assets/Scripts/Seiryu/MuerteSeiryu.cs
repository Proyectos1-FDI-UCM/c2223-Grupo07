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
    private float _time;
    private float _elapsedTime=0f;
    private float _elapsedTime2 = 0f;
    [SerializeField]
    private float _velocidad;
    private Vector3 directionSeiryu;
    private bool _entra = true;
    private bool _boom = true;

    // Start is called before the first frame update
    void Start()
    {
        _manager= GetComponent<SeiryuManager>();
        directionSeiryu = new Vector3(0, -15,0);
        _camera.SetActive(false);
        //_deadCamera.SetActive(true);
        _deadrocks.SetActive(true);
        PlayerManager.Instance.GetComponent<PlayerManager>().enabled = false;
        
        PlayerManager.Instance.GetComponent<InputComponent>().enabled= false;
        
        
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
                //Destroy(gameObject);
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
