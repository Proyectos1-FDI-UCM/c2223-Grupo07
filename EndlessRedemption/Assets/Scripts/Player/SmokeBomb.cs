using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : MonoBehaviour
{
    [SerializeField]
    private GameObject _bomb;  
    private float _elapsedTime;
    private float _cooldownElapsed;
    [SerializeField]
    private float _smokeTime;
    [SerializeField]
    private float _coolDown;
    private bool _smokeActive;
    private bool _smokeAvailable;
    [Header("Animation")]
    private Animator _animator;
    private GameObject _instanced;
    // Start is called before the first frame update
    void Start()
    {
        _smokeAvailable = true;
        _elapsedTime = 0;
        _cooldownElapsed = 0;
        _smokeActive = false;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_smokeActive)
        {
            _elapsedTime += Time.deltaTime;
        }
        else _cooldownElapsed += Time.deltaTime;
        if (_cooldownElapsed > _coolDown)
        {
            _cooldownElapsed = 0;
            _smokeAvailable = true;
        }
        if(_elapsedTime > 0.5)
        {
            Destroy(_instanced);
        }
        if(_elapsedTime > _smokeTime)
        {
            _smokeAvailable = false;
            _smokeActive = false;
            _elapsedTime = 0;           
        }
        _animator.SetBool("Smoke", _smokeActive);
    }
    public void ActivateSmoke()
    {
        if(_smokeAvailable && !_smokeActive)
        {
           
            _instanced =  Instantiate(_bomb, transform.position, new Quaternion (0,0,0,1));
            _smokeActive = true;
        }
        
    }
}
