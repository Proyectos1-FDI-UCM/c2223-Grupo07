using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeComponent : MonoBehaviour
{
    [SerializeField]
    public int vidasEnemy;

    #region methods

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidasEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
