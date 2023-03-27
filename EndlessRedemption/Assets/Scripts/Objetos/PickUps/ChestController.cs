using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    private SoundManager _soundManager;
    [SerializeField]
    private GameObject shurikenTutorial;

    // Start is called before the first frame update
    void Start()
    {
        _opened = false;
        _spawned = false;
        _animator = GetComponent<Animator>();
        _animator.SetBool("Open", _opened);       
        _soundManager = FindObjectOfType<SoundManager>();
        if (GetComponent<SeiryuManager>()) { _opened = true; }
        _elapsedTime = 0;
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
                shurikentTutorial.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(!GetComponent<SeiryuManager>())
        {
            if (collider.GetComponent<DamageComponent>() != null && !_opened)
            {
                _opened = true;
                _animator.SetBool("Open", _opened);
                _soundManager.SeleccionAudio(3, 0.5f);
            }
        }
        
    }
    public void Restart()
    {
        _opened = true;
        _elapsedTime = 0;
        _spawned = false;
    }
}
