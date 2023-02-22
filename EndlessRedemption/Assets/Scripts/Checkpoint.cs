using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.Instance.transform.position.x == transform.position.x)
        {
            GameManager.Instance._currentCheckpoint++;
            this.enabled = false;
        }
    }
}
