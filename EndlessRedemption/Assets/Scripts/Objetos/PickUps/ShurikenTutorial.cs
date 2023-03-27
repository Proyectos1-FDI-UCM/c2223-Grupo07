using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenTutorial : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetButtonDown("R1")) gameObject.SetActive(false);
    }
}
