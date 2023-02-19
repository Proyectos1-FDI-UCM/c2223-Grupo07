using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Transform _myTransform;
    public float _elapsedTime;
    public float _timeInvulnerable;
    private bool _invulnerable = false;
    public int vidasPlayer = 3;
    [Header("Animation")]
    private Animator _animator;

    static private PlayerManager _instance;
    static public PlayerManager Instance { get { return _instance; } }

    #region methods

    public void Invulnerable(float timeInvulnerable)
    {
        _invulnerable = true;
        _timeInvulnerable = timeInvulnerable;
    }
    #endregion

    void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _myTransform= transform;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("Smoke", _invulnerable);
        if (_invulnerable)
        {
            gameObject.layer = 8;
            _elapsedTime += Time.deltaTime;
            if(_elapsedTime > _timeInvulnerable)
            {
                gameObject.layer = 3;
                _invulnerable = false;
                _elapsedTime = 0;
            }
        }
    }
}
