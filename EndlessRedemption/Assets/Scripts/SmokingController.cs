using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokingController : MonoBehaviour
{
    [SerializeField]
    private GameObject _stopSmoke;
    
    private bool _stop;
    // Start is called before the first frame update
    void Start()
    {
        _stop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_stop && (PlayerManager.Instance.GetComponent<Rigidbody2D>().velocity.x > 1 || PlayerManager.Instance.GetComponent<Rigidbody2D>().velocity.x < -1) || !PlayerManager.Instance.GetComponent<MovementComponent>()._onGround)
        {
            _stopSmoke.SetActive(false);
            _stop = false;
        }
        else if (!_stop && PlayerManager.Instance.GetComponent<Rigidbody2D>().velocity.x < 1 && PlayerManager.Instance.GetComponent<Rigidbody2D>().velocity.x > -1 && PlayerManager.Instance.GetComponent<MovementComponent>()._onGround)
        {         
            _stopSmoke.SetActive(true);
            _stop = true;
        }
            
        

    }
}
