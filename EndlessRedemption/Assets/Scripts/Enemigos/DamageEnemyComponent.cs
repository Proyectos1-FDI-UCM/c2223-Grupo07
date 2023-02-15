using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DamageEnemyComponent : MonoBehaviour
{
    public int _damage;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>())
        {
            collision.gameObject.GetComponent<PlayerLifeComponent>().vidasPlayer-=_damage;           
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
