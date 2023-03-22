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
                    SelectSong(0, 0.3f);
                    SelectSong(1, 2f);
                    break;
                case 3:
                    SelectSong(0, 0.3f);
                    SelectSong(1, 0.1f);
                    break;
                case 4:
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
                    SelectSong(0, 0.3f);
                    SelectSong(1, 2f);
                    break;
                case 3:
                    SelectSong(0, 0.3f);
                    SelectSong(1, 0.1f);
                    break;
                case 4:
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
                    break;
                case 4:
                    break;
            }
        }
        
    }
}
