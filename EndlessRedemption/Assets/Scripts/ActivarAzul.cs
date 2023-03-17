using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAzul : MonoBehaviour
{
    private bool _iniciar=false;
    private float _time = 3f;
    private float _time2=4f;
    private float _time3=5f; 
    private float _time4=6f;
    private float _time5=6.5f;
    private float _elapsedTime;



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerManager>())
        {
            transform.GetChild(6).gameObject.SetActive(true);
            transform.GetChild(7).gameObject.SetActive(true);
            transform.GetChild(8).gameObject.SetActive(true);
            transform.GetChild(9).gameObject.SetActive(true);
            transform.GetChild(10).gameObject.SetActive(true);
           
            _iniciar = true;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_iniciar)
        {
            _elapsedTime += Time.deltaTime;

            if ( _elapsedTime >= 2)
            {
                if (_elapsedTime >= _time)
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                }
                if (_elapsedTime >= _time2)
                {
                    transform.GetChild(3).gameObject.SetActive(true);
                }
                if (_elapsedTime >= _time3)
                {
                    transform.GetChild(1).gameObject.SetActive(true);
                }
                if (_elapsedTime >= _time4)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                }
                if (_elapsedTime >= _time5)
                {
                    transform.GetChild(4).gameObject.SetActive(true);
                    transform.GetChild(5).gameObject.SetActive(true);
                }
                if (_elapsedTime >= 8)
                {
                    Destroy(gameObject);
                }
            }
        }
      
    }
}
