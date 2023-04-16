using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CinematicaSuicidio : MonoBehaviour
{
    private float _elapsedTime = 0;
    [SerializeField]
    private float _timeStill1;
    [SerializeField]
    private float _timeStill2;
    [SerializeField]
    private float _timeMoving;
    [SerializeField]
    private float _timeFalling;
    [SerializeField]
    private float _timeBlack;
    [SerializeField]
    private float _timeComentario3;
    private MovementComponent _movementComponent;
    private InputComponent _myInputComponent;
    private bool _stopMoving = false;
    [SerializeField]
    private float _rotation = 0.5f;
    [SerializeField]
    private float _speed = 500;
    private Rigidbody2D _myrb2D;
    private float _empujeFuerza = 5f;
    private bool _inputDesactivado = true;
    private bool _noEmpujar = false;
    private bool _doitOnce = true;
    [SerializeField]
    private GameObject _pantallaEnNegro;
    [SerializeField]
    private GameObject _comentario1;
    [SerializeField]
    private GameObject _comentario2;
    [SerializeField]
    private GameObject _comentario3;
    [SerializeField]
    private Transform _checkpoint1;
    [SerializeField]
    private GameObject _banda1;
    [SerializeField]
    private GameObject _banda2;
    [SerializeField]
    private GameObject _hud;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Cine") == 1)//Para que no se repita cada vez que mueres
            this.enabled = false;
        else
        {
            _movementComponent = GetComponent<MovementComponent>();
            _myrb2D = GetComponent<Rigidbody2D>();
            _myInputComponent = GetComponent<InputComponent>();
            _banda1.SetActive(true);
            _banda2.SetActive(true);
            _hud.SetActive(false);
        }
       
    }

    void FixedUpdate()
    {     
        

        if (!_stopMoving) _comentario1.SetActive(true);

        if(_elapsedTime > _timeStill1 && !_stopMoving)
        {
            Debug.Log("hey");
            _comentario1.SetActive(false);
            _movementComponent.Right();
            
            if (_elapsedTime > _timeMoving)
            {
                _stopMoving= true;
                _elapsedTime= 0;
            }
        }

        if (_stopMoving && _elapsedTime > _timeStill2 && _elapsedTime < _timeFalling)
        {
           _comentario2.SetActive(true);
            if(!_noEmpujar) _myrb2D.AddForce(Vector2.right * _empujeFuerza, ForceMode2D.Impulse);
            _noEmpujar = true; //Solo una vez
            transform.Rotate(0, 0, -_rotation);
        }

        if(_elapsedTime > _timeFalling && _doitOnce)
        {
            transform.position = _checkpoint1.transform.position;
            _pantallaEnNegro.SetActive(true);
            _comentario2.SetActive(false);
            SoundManager.Instance.SeleccionAudio(18, 2f);
            PlayerPrefs.SetInt("Cine", 1);
            _doitOnce= false;
        }
        if (_elapsedTime > _timeBlack)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            _pantallaEnNegro.SetActive(false);
            _comentario3.SetActive(true);
            _inputDesactivado = false;
        }
        if (_elapsedTime > _timeComentario3)
        {
            _comentario3.SetActive(false);
            _banda1.SetActive(false);
            _banda2.SetActive(false);
            _hud.SetActive(true);
            this.enabled = false;
        }
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_inputDesactivado) _myInputComponent.enabled = false;
        else _myInputComponent.enabled = true;
    }
}
