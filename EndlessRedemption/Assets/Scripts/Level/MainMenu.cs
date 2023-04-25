using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayNormalGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Lifes", 5);
        PlayerPrefs.SetInt("Shurikens", 30);
        PlayerPrefs.SetInt("Deaths", 0);
        SceneManager.LoadScene("CinematicaInicio"); //Cargar juego en modo normal      
    }

    public void PlayNightmareGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Lifes", 3);
        PlayerPrefs.SetInt("Shurikens", 15);
        PlayerPrefs.SetInt("Deaths", 0);
        SceneManager.LoadScene("CinematicaInicio");    
    }
    public void NightmareGame1()//para que el pesadilla sea como el antiguo que no recuperas vidas pero empiezas con 3
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Modo", "pesadilla");
        PlayerPrefs.SetInt("Shurikens", 10);
        PlayerPrefs.SetInt("Deaths", 0);
        SceneManager.LoadScene("CinematicaInicio");
    }

    public void UltraNightmareGame()//Una vida
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Lifes", 1);
        PlayerPrefs.SetInt("Shurikens", 10);
        PlayerPrefs.SetInt("Deaths", 0);
        SceneManager.LoadScene("CinematicaInicio");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); //Saldrá del ejecutable
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelX") + 1);
    }
}
