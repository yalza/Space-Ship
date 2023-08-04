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

    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            ExitGame();
        }
    }

    private void UpdateScore()
    {
        Score = Score + 1;
    }

    private void ExitGame()
    {
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
                Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        #endif
        #if (UNITY_EDITOR)
                UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE)
                            Application.Quit();
        #elif (UNITY_WEBGL)
                            SceneManager.LoadScene("QuitScene");
        #endif
    }
}
