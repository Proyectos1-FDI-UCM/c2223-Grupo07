using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void Level1()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelX", 1);       
        PlayerPrefs.SetInt("Lifes", 5);
        PlayerPrefs.SetInt("Shurikens", 30);
        PlayerPrefs.SetInt("Deaths", 0);
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("hasDash", 1);
        PlayerPrefs.SetInt("hasDoubleJump", 1);
        PlayerPrefs.SetInt("LevelX", 2);
        PlayerPrefs.SetInt("Lifes", 5);
        PlayerPrefs.SetInt("Shurikens", 30);
        PlayerPrefs.SetInt("Deaths", 0);
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelX", 3);
        PlayerPrefs.SetInt("hasDash", 1);
        PlayerPrefs.SetInt("hasDoubleJump", 1);
        PlayerPrefs.SetInt("Lifes", 5);
        PlayerPrefs.SetInt("Shurikens", 30);
        PlayerPrefs.SetInt("Deaths", 0);
        SceneManager.LoadScene("Level3");
    }
    public void Level4()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelX", 4);
        PlayerPrefs.SetInt("hasDash", 1);
        PlayerPrefs.SetInt("hasDoubleJump", 1);
        PlayerPrefs.SetInt("Lifes", 5);
        PlayerPrefs.SetInt("Shurikens", 30);
        PlayerPrefs.SetInt("Deaths", 0);
        SceneManager.LoadScene("Level4");
    }
    public void Level5()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("hasDash", 1);
        PlayerPrefs.SetInt("hasDoubleJump", 1);
        PlayerPrefs.SetInt("LevelX", 5);
        PlayerPrefs.SetInt("Lifes", 5);
        PlayerPrefs.SetInt("Shurikens", 30);
        PlayerPrefs.SetInt("Deaths", 0);
        SceneManager.LoadScene("Level5");
    }
}
