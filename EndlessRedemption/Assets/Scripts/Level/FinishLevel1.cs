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

    private void Start()
    {
        _transitionAnimator = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("LevelX", _nextLevel);
        PlayerPrefs.SetInt("CheckpointX", 0);
        StartCoroutine(SceneLoad(_nextLevel));
    }

    private IEnumerator SceneLoad(int _nextLevel)
    {
        _transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(_nextLevel + 1);
    }
}
