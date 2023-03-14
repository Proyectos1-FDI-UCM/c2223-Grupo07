using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShurikenLauncher : MonoBehaviour
{
    public enum Direction {RIGHT, LEFT, UP, DOWN}
    public Direction _expectedDirection;
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private GameObject _shuriken;
    [SerializeField]
    private float _speed;
    private SoundManager _soundManager;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _soundManager = FindObjectOfType<SoundManager>();
    }


    public void LateralThrow()
    {
        if(GameManager.Instance._currenShurikens > 0)
        {
            if (transform.localScale.x > 0)
                _expectedDirection = Direction.RIGHT;
            else _expectedDirection = Direction.LEFT;
            Instantiate(_shuriken, transform.position, Quaternion.identity);
            GameManager.Instance._currenShurikens--;
            _soundManager.SeleccionAudio(9, 0.5f);
        }
      
    }
    public void UpThrow()
    {
        if (GameManager.Instance._currenShurikens > 0)
        {
            _expectedDirection = Direction.UP;
            Instantiate(_shuriken, transform.position, Quaternion.identity);
            GameManager.Instance._currenShurikens--;
            _soundManager.SeleccionAudio(9, 0.5f);
        }
        
    }
    public void DownThrow()
    {
        if (GameManager.Instance._currenShurikens > 0)
        {
            _expectedDirection = Direction.DOWN;
            Instantiate(_shuriken, transform.position, Quaternion.identity);
            GameManager.Instance._currenShurikens--;
            _soundManager.SeleccionAudio(9, 0.5f);
        }
    }
    
}
