using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resurrection : MonoBehaviour
{
    [SerializeField]
    private GameObject _resurrection;
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(_resurrection, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
