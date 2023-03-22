using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayNormalGame()
    {
        SceneManager.LoadScene("Level1"); //Cargar juego en modo normal
        PlayerPrefs.DeleteAll();
    }

    public void PlayNightmareGame()
    {
       
        SceneManager.LoadScene("Level1"); //Cargar juego en modo pesadilla
        GameManager.Instance._maxLifes = 3;
        GameManager.Instance._maxShurikens = 10;

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); //Saldr� del ejecutable
    }
}
