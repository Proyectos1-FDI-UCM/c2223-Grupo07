using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClean : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _background;
    private float _elapsed;
    [SerializeField]
    private float _timeToClean;
    private bool _clean;
    // Start is called before the first frame update
    private void Start()
    {
        _clean = false;
    }

    // Update is called once per frame
    void Update()
    {
        _elapsed += Time.deltaTime;
        if(_elapsed > _timeToClean && !_clean)
        {
            _clean = true;
            _background[_background.Length -1].SetActive(false);
            for (int i = 0; i < _background.Length -1; i++)
            {
                _background[i].SetActive(true);
            }
           
        }
    }
}
