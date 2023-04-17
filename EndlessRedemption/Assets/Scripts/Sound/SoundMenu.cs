using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _audioClips;
    private AudioSource _audioSourceMenu;
    // Start is called before the first frame update
    void Start()
    {
        _audioSourceMenu = GetComponent<AudioSource>();
        PlaySound(0, 0.2f);
     
    }
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Studio") == 1)
        {
            GetComponent<UIClean>()._timeToClean = 0;

        }
    }

    // Update is called once per frame

    private void PlaySound(int pista, float volume)
    {
        _audioSourceMenu.PlayOneShot(_audioClips[pista], volume);
    }
}
