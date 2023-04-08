using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicText : MonoBehaviour
{
    [SerializeField]
    private Collider2D _finishlevel;
    [SerializeField]
    private GameObject[] _tutorialBoxes;//array de cajas de texto
    private float _elapsedTime = 0f;
    private float _boxTime = 8f;
    private bool _boxClicked = false;
    private int i = 0; //indice del array
    private void Start()
    {
        _finishlevel.enabled = false;
    }
    public void ClickBox()
    {
        _tutorialBoxes[i].SetActive(false);
        _boxClicked = true;
        Next();
     
        
    }  
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if (i < _tutorialBoxes.Length - 1)
            {
                ClickBox();
            }
        }           
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _boxTime)
            {
                if (i < _tutorialBoxes.Length - 1)
                {
                Next();
                }
            
            }
        if (i == _tutorialBoxes.Length - 1)
        {
            _finishlevel.enabled = true;
        }

    }
    private void Next()
    {
      
        _tutorialBoxes[i + 1].SetActive(true);
        _elapsedTime = 0f;
        i++;
        Debug.Log(i);
        Debug.Log(_tutorialBoxes.Length);
        _boxClicked = false;
    }
}
