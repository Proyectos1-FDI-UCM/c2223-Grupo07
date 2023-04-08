using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicText : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _tutorialBoxes;//array de cajas de texto
    private float _elapsedTime = 0f;
    private float _boxTime = 8f;
    private bool _boxClicked = false;
    private int i = 0; //indice del array

    public void ClickBox()
    {
        _tutorialBoxes[i].SetActive(false);
        _boxClicked = true;
        Next();
        Debug.Log("Click");
        
    }  
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ClickBox();
        }           
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _boxTime)
            {
                if (i < _tutorialBoxes.Length - 1)
                {
                Next();
                }               
            } 
            
    }
    private void Next()
    {
        _tutorialBoxes[i + 1].SetActive(true);
        _elapsedTime = 0f;
        i++;
        _boxClicked = false;
    }
}
