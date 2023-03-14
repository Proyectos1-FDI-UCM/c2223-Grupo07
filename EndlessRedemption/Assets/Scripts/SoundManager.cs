using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _audios;

    private AudioSource _controlAudio;
    // Start is called before the first frame update
    void Start()
    {
        _controlAudio = GetComponent<AudioSource>();
    }

    public void SeleccionAudio(int indice, float volumen)
    {
        _controlAudio.PlayOneShot(_audios[indice], volumen);
    }
}
