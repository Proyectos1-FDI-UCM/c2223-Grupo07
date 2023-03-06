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
    private GameObject DashIcon;
    [SerializeField]
    private GameObject DoubleJumpIcon;

    private void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        shurikenText.SetText("x" + GameManager.Instance._currenShurikens);
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

