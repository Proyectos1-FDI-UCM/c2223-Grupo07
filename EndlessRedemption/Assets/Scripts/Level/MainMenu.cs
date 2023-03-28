using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayNormalGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Lifes", 3);
        PlayerPrefs.SetInt("Shurikens", 15);
        SceneManager.LoadScene("Level1"); //Cargar juego en modo normal      
    }

    public void PlayNightmareGame()
    {
        PlayerPrefs.SetInt("Lifes", 3);
        PlayerPrefs.SetInt("Shurikens", 15);
        SceneManager.LoadScene("Level1"); //Cargar juego en modo pesadilla    
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); //Saldrá del ejecutable
    }
}
