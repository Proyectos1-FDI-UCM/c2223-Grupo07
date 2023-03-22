using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel1 : MonoBehaviour
{
    [SerializeField]
    private int _nextLevel;

    [SerializeField]
    private float _transitionTime = 1f;
    private Animator _transitionAnimator;

    private GameManager _gameManager;

    private void Start()
    {
        _transitionAnimator = GetComponentInChildren<Animator>();
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("FirstRound", 0);
        PlayerPrefs.SetInt("LevelX", _nextLevel);
        PlayerPrefs.SetInt("CheckpointX", 0);
        StartCoroutine(SceneLoad(_nextLevel));
    }

    private IEnumerator SceneLoad(int _nextLevel)
    {
        _transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(_transitionTime);
        if (_gameManager._hasDeath) SceneManager.LoadScene(_nextLevel);
        else SceneManager.LoadScene(_nextLevel + 1);
    }
}
