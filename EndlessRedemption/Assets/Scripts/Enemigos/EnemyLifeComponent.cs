using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeComponent : MonoBehaviour
{
    [SerializeField]
    public int vidasEnemy;
    [SerializeField]
    private GameObject VidaPickUp;
    private GameObject aux;
    private float thrust = 3f;
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
                aux = Instantiate(VidaPickUp, transform.position, Quaternion.identity);
                aux.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            }
            Destroy(gameObject);
        }
    }
}
