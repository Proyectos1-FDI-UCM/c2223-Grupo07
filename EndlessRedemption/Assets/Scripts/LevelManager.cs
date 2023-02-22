using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int _level;
    // Start is called before the first frame update
    void Start()
    {
        _level = PlayerPrefs.GetInt("LevelX");
        switch (_level)
        {
            case 1:
                SceneManager.LoadScene("Level1");
                break;
            case 2:
                SceneManager.LoadScene("Level2");
                break;
            case 3:
                SceneManager.LoadScene("Level3");
                break;
            case 4:
                SceneManager.LoadScene("Level4 Dragon");
                break;
            default:
                break;           
        }
    }

  
    
}
