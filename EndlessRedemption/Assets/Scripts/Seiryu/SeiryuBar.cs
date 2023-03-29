using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeiryuBar : MonoBehaviour
{
    static private SeiryuBar _seiryuBar;
    static public SeiryuBar Instance { get { return _seiryuBar; } } 
    public Slider slider;
    private void Awake()
    {
        _seiryuBar = this;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
