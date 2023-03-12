using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLife : MonoBehaviour
{
    [SerializeField]
    private float _timeLife;
    private float _elapsed;
    // Start is called before the first frame update
    void Start()
    {
        _elapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _elapsed += Time.deltaTime;
        if (_elapsed > _timeLife)
            Destroy(gameObject);
    }
}
