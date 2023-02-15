using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Transform _myTransform;
    public float _elapsedTime;
    public float _timeInvulnerable;
    private bool _invulnerable = false;

    #region methods

    public void Invulnerable()
    {
        _invulnerable = true;
    }

    #endregion

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
            }
        }
    }
}
