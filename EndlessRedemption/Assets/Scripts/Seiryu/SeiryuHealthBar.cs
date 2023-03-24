using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeiryuHealthBar : MonoBehaviour
{
    public Slider slider;

    [SerializeField]
    private GameObject Inicio;//Rectangulo del principio de la vida
    [SerializeField]
    private GameObject Final;//Rectangulo del final de la vida

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        if(health < 60)Inicio.SetActive(false);
        if (health <= 0) Final.SetActive(false);
    }
}
