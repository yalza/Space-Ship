using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int _score = 0;
    public int Score
    {
        get
        {
            return _score;
        }
        private set
        {
            _score = value;
        }
    }

    private void Start()
    {
        Observer.Instant.RegisterObserver(Constant.EnemyDeadKey, UpdateScore);
    }

    private void UpdateScore()
    {
        Score = Score + 1;
    }
}
