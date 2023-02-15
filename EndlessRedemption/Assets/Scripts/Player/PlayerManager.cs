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

    static private PlayerManager _instance;
    static public PlayerManager Instance { get { return _instance; } }

    #region methods


    #endregion

    void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _myTransform= transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_invulnerable)
        {
            gameObject.layer = 8;
            _elapsedTime += Time.deltaTime;
            if(_elapsedTime > _timeInvulnerable)
            {
                gameObject.layer = 7;
                _invulnerable = false;
            }
        }
    }
}
