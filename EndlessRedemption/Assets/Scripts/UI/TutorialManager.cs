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
        _tutorialBoxes[i].SetActive(false);
        _boxClicked = true;
        Debug.Log("Click");
    }

    private void OnTriggerEnter2D(Collider2D collider2D)//Trigger puesto en el primer checkpoint
    {
        _tutorial.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        switch (i)//cada caja de texto desaparece para dar paso a la siguiente dependiendo del input que coincide con la mecánica enseñada
        {
            case 0:
                if(Input.GetKey(KeyCode.A) || Input.GetAxis("StickHorizontal") == -1)
                {
                     ClickBox();
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
                {
                    ClickBox();
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Square"))
                {
                    ClickBox();
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Triangle"))
                {
                    ClickBox();
                }
                break;
        }

        if (_boxClicked)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _boxTime)
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
