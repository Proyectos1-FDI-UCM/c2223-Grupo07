using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField]
    private GameObject _pickUp;
    private bool _opened;
    private bool _spawned;
    private Animator _animator;
    private float _elapsedTime;
    [SerializeField]
    private int _ShurikensSpawned;
    [SerializeField]
    private float _spawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _opened = false;
        _animator = GetComponent<Animator>();
        _animator.SetBool("Open", _opened);
        _spawned= false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_opened)
        {
            _elapsedTime += Time.deltaTime;
        }
        if(_elapsedTime> _spawnTime && !_spawned) 
        {
            _spawned= true;
            for (int i = 0; i < _ShurikensSpawned; i++)
            {
                Instantiate(_pickUp, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<DamageComponent>() != null && !_opened)
        {
            _opened= true;
            _animator.SetBool("Open", _opened);
        }
    }
}
