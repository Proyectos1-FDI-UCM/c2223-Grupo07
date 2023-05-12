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
    private float _elapsed = 0;
    private int prob;
    private bool _taken;
    private bool _once = false;

    // Start is called before the first frame update
    public void Muerte()
    {
        vidasEnemy= 0;
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
            _elapsed += Time.deltaTime;
            if (!GetComponent<SeiryuManager>())
            {
                if (prob == 0 && !_taken)
                {
                    _taken = true;
                    aux = Instantiate(VidaPickUp, transform.position, Quaternion.identity);
                    aux.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);

                }
                if(!_once)
                {
                
                    Instantiate(_deadExplosion, transform.position, Quaternion.identity);
                    Time.timeScale = 0.5f;
                    SoundManager.Instance.SeleccionAudio(22, 0.4f);
                    _once = true;
                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<Collider2D>().enabled = false;
                }
                if(_elapsed > 0.4f)
                {
                    Time.timeScale = 1f;
                    Destroy(gameObject);
                }
          
               
            }
            else this.enabled = false;
    
        }
    }
}
