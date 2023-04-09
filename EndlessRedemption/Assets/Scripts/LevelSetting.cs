using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetting : MonoBehaviour
{
    [SerializeField]
    private int _currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("LevelX", _currentLevel - 1);
    }

   
}
