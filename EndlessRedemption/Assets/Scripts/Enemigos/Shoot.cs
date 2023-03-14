using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private GameObject _bullet;    
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private float _shootInterval;
    private float _elapsedTime = 0;
    private IABountyHunter1 _IABountyHunter;
    private FireDragon _fireDragon;
    [SerializeField]
    private Vector3 _offset;

    private SoundManager _soundManager;
    // Start is called before the first frame update
    void Start()
    {
        _IABountyHunter = GetComponent<IABountyHunter1>();
        _fireDragon = GetComponent<FireDragon>();
        _soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<IABountyHunter1>())
        {
            if (_IABountyHunter._currentState == IABountyHunter1.BountyHunterStates.SHOOTING)
            {
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime > _shootInterval)
                {
                    Instantiate(_explosion, (transform.position + _offset), Quaternion.identity);
                    GameObject bullet = Instantiate(_bullet, transform.position + _offset, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = _IABountyHunter._vectorDirection * _bulletSpeed;
                    _elapsedTime = 0;
                }
            }
        }
        if (GetComponent<FireDragon>())
        {
            if (_fireDragon._currentState == FireDragon.DragonStates.SHOOTING)
            {
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime > _shootInterval)
                {
                    Instantiate(_explosion, (transform.position + _offset), Quaternion.identity);
                    GameObject bullet = Instantiate(_bullet, transform.position + _offset, Quaternion.identity);
                    _elapsedTime = 0;
                    _soundManager.SeleccionAudio(5, 0.5f);
                }
            }
        }


    }
}
