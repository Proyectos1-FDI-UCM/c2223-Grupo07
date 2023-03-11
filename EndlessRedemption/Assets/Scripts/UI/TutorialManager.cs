using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _tutorial;//Objeto con las cajas de texto

    private void OnTriggerEnter2D(Collider2D collider2D)//Trigger puesto en el primer checkpoint
    {
        _tutorial.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
