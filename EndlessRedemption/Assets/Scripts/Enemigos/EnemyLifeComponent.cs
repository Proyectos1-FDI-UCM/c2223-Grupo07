using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeComponent : MonoBehaviour
{
    [SerializeField]
    public int vidasEnemy;
    [SerializeField]
    private GameObject VidaPickUp;
    [SerializeField]
    private GameObject _deadExplosion;
    private GameObject aux;
    private float thrust = 3f;
    private int prob;
    private bool _taken;

    // Start is called before the first frame update
    public void Muerte()
    {
        vidasEnemy = 0;
        MuerteBool();
    }

    public bool MuerteBool()
    {
        return vidasEnemy == 0;
    }
    void Start()
    {
        prob = Random.Range(0,4);
        _taken = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (vidasEnemy <= 0)
        {
            if(prob == 0 && !_taken)
            {
                _taken = true;
                aux = Instantiate(VidaPickUp, transform.position, Quaternion.identity);
                aux.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            }
            Instantiate(_deadExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
