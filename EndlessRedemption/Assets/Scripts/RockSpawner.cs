using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    private float _elapsedTime = 0;
    [SerializeField]
    private float _time;
    [SerializeField]
    private GameObject[] spawners;
    private int index = 0;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        _elapsedTime+= Time.deltaTime;
        if(_elapsedTime > _time && index < spawners.Length)
        {
            spawners[index].SetActive(true);
           
                  
            index++;
            _elapsedTime = 0;
        }
    }
    private void Start()
    {
        SoundManager.Instance.SeleccionAudio(18, 2f);
        
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].SetActive(false);

        }
    }
}
