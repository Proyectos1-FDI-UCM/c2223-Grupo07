using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarTutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject _tutorial;

    private void OnTriggerEnter2D(Collider2D collider2D)//Activa el tutorial y se autodestruye
    {
        _tutorial.SetActive(true);
        Destroy(gameObject);
    }
}
