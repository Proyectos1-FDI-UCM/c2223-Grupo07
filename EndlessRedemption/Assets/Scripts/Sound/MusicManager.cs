using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _audioClips;
    private AudioSource _audioSourceMusic;
    private MusicManager _musicManager;
    [SerializeField]
    private bool _playAtStart;
    private bool _enterZone;
    public MusicManager MusicManage {get {return _musicManager;}}
    // Start is called before the first frame update
    private void Awake()
    {
        _musicManager = this;
    }
    void Start()
    {
        _enterZone = false;
        _audioSourceMusic = GetComponent<AudioSource>();
        if(_playAtStart)
        switch(PlayerPrefs.GetInt("LevelX"))
            {
                case 0:
                    SelectSong(0, 0.4f);
                    SelectSong(1, 0.5f);
                    break;
                case 1:
                    SelectSong(1, 0.4f);
                    SelectSong(2, 0.6f);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
    }
    public void SelectSong(int pista, float volume)
    {
        _audioSourceMusic.PlayOneShot(_audioClips[pista], volume);
    }
    public void StopMusic()
    {
        _audioSourceMusic.Stop();
    }
    
    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)//Cambio de musica al entrar en una zona
    {
        if(!_enterZone)
        {
            _enterZone = true;
            StopMusic();
            switch (PlayerPrefs.GetInt("LevelX"))
            {
                case 0:
                    SelectSong(2, 1f);
                    break;
                case 1:

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
        
    }
}
