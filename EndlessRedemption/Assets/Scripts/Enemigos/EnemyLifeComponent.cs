using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeComponent : MonoBehaviour
{
    [SerializeField]
    private int vidasEnemy;

    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            vidasEnemy--;
            Debug.Log("Vidas enemigo:" + vidasEnemy);
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
