using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    private float _elapsedTime = 0;
    [SerializeField]
    private float _time;
    private ChestController _rockSpawn;
    // Start is called before the first frame update
    void Start()
    {
        _rockSpawn= GetComponent<ChestController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime+= Time.deltaTime;
        if(_elapsedTime > _time)
        {
            _rockSpawn.enabled= false;
            _rockSpawn.enabled= true;
            _elapsedTime = 0;
        }
    }
}
