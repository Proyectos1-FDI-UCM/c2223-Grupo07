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
    private TMP_Text _DBJumpCooldown;
    [SerializeField]
    private GameObject DashIcon;
    [SerializeField]
    private GameObject DoubleJumpIcon;

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
        shurikenText.SetText("x" + GameManager.Instance._currenShurikens);
        if (Mathf.Round(PlayerManager.Instance.GetComponent<MovementComponent>().Cooldown - PlayerManager.Instance.GetComponent<MovementComponent>()._cooldownElapsed) == PlayerManager.Instance.GetComponent<MovementComponent>().Cooldown)
            _dashCooldown.SetText(" ");//Si dash cargado que no se vea el cooldown
        else//Cooldown dash
        _dashCooldown.SetText("" + Mathf.Round(PlayerManager.Instance.GetComponent<MovementComponent>().Cooldown - PlayerManager.Instance.GetComponent<MovementComponent>()._cooldownElapsed));

        if (Mathf.Round(PlayerManager.Instance.GetComponent<SmokeBomb>().SmokeCoolDown - PlayerManager.Instance.GetComponent<SmokeBomb>()._elapsedTime) == PlayerManager.Instance.GetComponent<SmokeBomb>().SmokeCoolDown)
            _DBJumpCooldown.SetText(" ");
        else _DBJumpCooldown.SetText("" + Mathf.Round((PlayerManager.Instance.GetComponent<SmokeBomb>().SmokeCoolDown - 1) - PlayerManager.Instance.GetComponent<SmokeBomb>()._elapsedTime));
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

