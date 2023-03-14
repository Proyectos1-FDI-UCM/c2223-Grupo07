using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _tutorial;//Objeto con las cajas de texto

    [SerializeField]
    private GameObject[] _tutorialBoxes = new GameObject[4];//array de cajas de texto
    private float _elapsedTime = 0f;
    private float _boxTime = 1f;
    private bool _boxClicked = false;
    private int i = 0; //indice del array

    public void ClickBox()
    {
        _boxClicked = true;
        Debug.Log("Click");
    }

    private void OnTriggerEnter2D(Collider2D collider2D)//Trigger puesto en el primer checkpoint
    {
        _tutorial.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_boxClicked)
        {
            _tutorialBoxes[i].SetActive(false);
            _elapsedTime += Time.deltaTime;
            if(_elapsedTime > _boxTime)
            {
                if (i < 3)
                {
                    _tutorialBoxes[i + 1].SetActive(true);
                    _elapsedTime = 0f;
                    i++;
                    _boxClicked = false;
                }
            }  
        }
    }
}
