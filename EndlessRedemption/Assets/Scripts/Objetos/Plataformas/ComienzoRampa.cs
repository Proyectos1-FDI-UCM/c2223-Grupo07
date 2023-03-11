using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComienzoRampa : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<MovementComponent>())
        {
            collider.GetComponent<MovementComponent>().DecreaseFallSpeed(10);
            collider.GetComponent<InputComponent>().enabled = false;
            collider.GetComponent<InputRampa>().enabled = true;
        }
    }
}
