using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Vidas = new GameObject[5];
    private int _vidas;
    static private UIManager _instance;
    static public UIManager Instance { get { return _instance; } }
    [SerializeField]
    private TMP_Text shurikenText;

    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shurikenText.SetText("x" + GameManager.Instance._currenShurikens);
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

