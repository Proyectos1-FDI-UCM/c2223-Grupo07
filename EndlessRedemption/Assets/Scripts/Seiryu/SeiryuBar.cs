using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeiryuBar : MonoBehaviour
{
    static private SeiryuBar _seiryuBar;
    static public SeiryuBar Instance { get { return _seiryuBar; } } 
    public Slider slider;
    [SerializeField]
    private GameObject _molestoText;
    [SerializeField]
    private GameObject _enfadadoText;
    [SerializeField]
    private GameObject _furiosoText;

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

    void Update()
    {
        switch ((int)SeiryuManager.Instance._currentBossState)
        {
            case 1:
                _molestoText.SetActive(false);
                _enfadadoText.SetActive(true);
                break;
            case 2:
                _enfadadoText.SetActive(false);
                _furiosoText.SetActive(true);
                break;
        }
    }
}
