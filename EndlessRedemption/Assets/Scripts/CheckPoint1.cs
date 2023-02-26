using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : MonoBehaviour
{
    [SerializeField]
    private int checkpoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerManager>())
        {
            PlayerPrefs.SetInt("CheckpointX", checkpoint);
            gameObject.SetActive(false);
            Debug.Log("Checkpoint "+checkpoint);
        }
    }
}
