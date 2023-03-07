using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindComponent : MonoBehaviour
{
    [SerializeField]
    private bool _right;
    [SerializeField]
    private float _windForce;
    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.gameObject.GetComponent<MovementComponent>())
        {
            if(_right)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * _windForce, ForceMode2D.Impulse);
            }
            else if (!_right)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * _windForce, ForceMode2D.Impulse);
            }

        }




    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
