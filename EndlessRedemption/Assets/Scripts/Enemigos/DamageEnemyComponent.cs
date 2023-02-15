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
            PlayerManager.Instance.vidasPlayer-=_damage;
            collision.gameObject.GetComponent<PlayerLifeComponent>().HitKnockBack(gameObject);
            PlayerManager.Instance.Invulnerable(2.0f);
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
