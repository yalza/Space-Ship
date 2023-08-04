using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Text scoreText;

    private void Start()
    {
        Observer.Instant.RegisterObserver(Constant.EnemyDeadKey, UpdateScoreText);
    }

    private void UpdateScoreText()
    {
        StartCoroutine(UpdateScoreTextCoroutine());
    }

    private IEnumerator UpdateScoreTextCoroutine()
    {
        yield return new WaitForEndOfFrame();
        int score = GameManager.Instant.Score;
        scoreText.text = "Score: " + score;
    }
}
