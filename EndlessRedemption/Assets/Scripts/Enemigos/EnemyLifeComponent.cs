using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeComponent : MonoBehaviour
{
    [SerializeField]
    public int vidasEnemy;
    [SerializeField]
    private GameObject VidaPickUp;
    private int prob;

    // Start is called before the first frame update
    void Start()
    {
        prob = Random.Range(0,3);
    }
    // Update is called once per frame
    void Update()
    {
        if (vidasEnemy <= 0)
        {
            if(prob == 0)
            {
                Instantiate(VidaPickUp, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
