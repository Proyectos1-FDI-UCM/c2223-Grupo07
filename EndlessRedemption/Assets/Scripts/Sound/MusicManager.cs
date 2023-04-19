using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _audioClips;
    private AudioSource _audioSourceMusic;
    static private MusicManager _musicManager;
    [SerializeField]
    private bool _playAtStart;
    private bool _enterZone;
    static public MusicManager Instance {get {return _musicManager;}}
    // Start is called before the first frame update
    private void Awake()
    {
        _musicManager = this;
    }
    void Start()
    {
        _enterZone = false;
        _audioSourceMusic = GetComponent<AudioSource>();
        
        if(_playAtStart && PlayerPrefs.GetInt("FirstRound") == 0)
        switch(PlayerPrefs.GetInt("LevelX"))//Musica y ambiente de cada level
            {
                case 0:
                    SelectSong(0, 0.4f);
                    SelectSong(1, 0.4f);
                    break;
                case 1:
                    SelectSong(1, 0.4f);
                    SelectSong(3, 0.8f);
                    break;
                case 2:
                    SelectSong(0, 0.1f);
                    SelectSong(1, 3f);
                    break;
                case 3:
                    SelectSong(0, 0.1f);
                    SelectSong(1, 0.1f);
                    break;
                case 4:
                    SelectSong(0, 0.4f);
                    SelectSong(1, 0.3f);
                    break;
                default:
                    SelectSong(0, 0.6f);
                    break;
            }
        if(PlayerPrefs.GetInt("FirstRound") == 1)
        {
            switch (PlayerPrefs.GetInt("LevelX"))//Musica y ambiente de cada level
            {
                case 0:
                    SelectSong(1, 0.4f);
                    SelectSong(3, 0.2f);
                    break;
                case 1:
                    SelectSong(1, 0.4f);
                    SelectSong(3, 0.8f);
                    break;
                case 2:
                    SelectSong(0, 0.1f);
                    SelectSong(1, 3f);
                    break;
                case 3:
                    SelectSong(0, 0.3f);
                    SelectSong(1, 0.1f);
                    break;
                case 4:
                    SelectSong(0, 0.4f);
                    SelectSong(1, 0.3f);
                    break;
            }
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
    public void PauseMusic()
    {
        _audioSourceMusic.Pause();
    }
    public void UnPauseMusic()
    {
        _audioSourceMusic.Play();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)//Cambio de musica al entrar en una zona
    {
        if (!_enterZone && collision.gameObject.GetComponent<PlayerManager>()) 
        {
            _enterZone = true;
            StopMusic();
            switch (PlayerPrefs.GetInt("LevelX"))
            {
                case 0:
                    SelectSong(2, 0.8f);
                    break;
                case 1:
                    SelectSong(0, 0.5f);
                    break;
                case 2:
                    SelectSong(2, 0.3f);
                    break;
                case 3:
                    SelectSong(3, 0.5f);
                    break;
                case 4:
                    break;
            }
        }
        
    }
}
