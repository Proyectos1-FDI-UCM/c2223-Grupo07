using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    public int vidasPlayer = 3;
    private Collider2D _myCollider2D;

    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemigo")
        {
            vidasPlayer--;
            Debug.Log(vidasPlayer);
        }
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidasPlayer > 10) vidasPlayer = 10;
    }
}
