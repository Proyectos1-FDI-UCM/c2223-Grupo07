using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Vidas = new GameObject[5];//Imagenes de vidas
    private int _vidas;
    static private UIManager _instance;
    static public UIManager Instance { get { return _instance; } }
    [SerializeField]
    private TMP_Text shurikenText;
    [SerializeField]
    private TMP_Text _dashCooldown;
    [SerializeField]
    private GameObject DashIcon;
    [SerializeField]
    private GameObject DoubleJumpIcon;
    [SerializeField]
    private GameObject ShurikenImage;
    [SerializeField]
    private GameObject[] SmokeBomb;
    [SerializeField]
    private TMP_Text _deaths;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("hasDash") == 1) ShowDashIcon();
        if (PlayerPrefs.GetInt("hasDoubleJump") == 1) ShowDoubleJumpIcon();
    }
    // Update is called once per frame
    void Update()
    {
        _deaths.SetText("x" +  PlayerPrefs.GetInt("Deaths"));
        if (GameManager.Instance._hasShurikensBag)
        {
            shurikenText.SetText("x" + GameManager.Instance._currenShurikens);
            ShurikenImage.SetActive(true);
        }
        else
        {
            ShurikenImage.SetActive(false);
        }
        if (Mathf.Round(PlayerManager.Instance.GetComponent<MovementComponent>().Cooldown - PlayerManager.Instance.GetComponent<MovementComponent>()._cooldownElapsed) == PlayerManager.Instance.GetComponent<MovementComponent>().Cooldown)
            _dashCooldown.SetText(" ");//Si dash cargado que no se vea el cooldown
        else//Cooldown dash
        _dashCooldown.SetText("" + Mathf.Round(1 +PlayerManager.Instance.GetComponent<MovementComponent>().Cooldown - PlayerManager.Instance.GetComponent<MovementComponent>()._cooldownElapsed));

        for (int i = 0; i < SmokeBomb.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("SmokeHits"))
            {
                SmokeBomb[i].SetActive(true);
            }
            else SmokeBomb[i].SetActive(false);
        }
    }

    public void ShowDashIcon()
    {
        DashIcon.SetActive(true);
    }

    public void ShowDoubleJumpIcon()
    {
        DoubleJumpIcon.SetActive(true);
    }

    public void GanaVidas()
    {
        _vidas = (int)(GameManager.Instance._lifes - 1f);
        if (_vidas < Vidas.Length)
        {
            Vidas[_vidas].SetActive(true);
        }
    }

    public void PierdeVidas()
    {
        _vidas = (int)(GameManager.Instance._lifes);
        if (_vidas < Vidas.Length)
        {
            Vidas[_vidas].SetActive(false);
        }
    }
}

