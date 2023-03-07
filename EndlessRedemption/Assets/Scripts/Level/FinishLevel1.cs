using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel1 : MonoBehaviour
{
    [SerializeField]
    private int _nextLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("LevelX", _nextLevel);
        PlayerPrefs.SetInt("CheckpointX", 0);
        SceneManager.LoadScene("Level2");
    }
}
