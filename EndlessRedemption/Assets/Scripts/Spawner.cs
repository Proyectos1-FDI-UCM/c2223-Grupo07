using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] _roomCentre;
    [SerializeField]
    private GameObject _dragon;
    [SerializeField]
    private float _time = 15f;
    private float _elapsed = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        _elapsed = _time - 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(SeiryuManager.Instance._currentBossState != SeiryuManager.BossStates.DEAD)
        _elapsed += Time.deltaTime;
        if(_elapsed > _time)
        {
            for (int i = 0; i < _roomCentre.Length; i++)
            {
                Instantiate(_dragon, _roomCentre[i].position, Quaternion.identity);
            }
            _elapsed = 0;
        }
    }
}
