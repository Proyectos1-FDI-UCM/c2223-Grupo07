using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    #region references
    private SoundManager _soundManager;
    [SerializeField]
    private GameObject _mocoEnemy;
    [SerializeField]
    private GameObject _spiderEnemy;
    [SerializeField]
    private GameObject _babyDragonEnemy;
    [SerializeField]
    private GameObject _soldierEnemy;
    [SerializeField]
    private GameObject _dragonEnemy;
    [SerializeField]
    private GameObject _bountyHunterEnemy;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _mocoEnemy) _soundManager.SeleccionAudio(3, 0.5f);
        else if (collision.gameObject == _spiderEnemy) _soundManager.SeleccionAudio(3, 0.5f);
        else if (collision.gameObject == _babyDragonEnemy) _soundManager.SeleccionAudio(3, 0.5f);
        else if (collision.gameObject == _soldierEnemy) _soundManager.SeleccionAudio(3, 0.5f);
        else if (collision.gameObject == _dragonEnemy) _soundManager.SeleccionAudio(3, 0.5f);
        else if (collision.gameObject == _bountyHunterEnemy) _soundManager.SeleccionAudio(3, 0.5f);
    }
}
