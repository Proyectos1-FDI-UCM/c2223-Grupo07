using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarFuego : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerManager>())
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
