using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int currentLevel;
    private int lives;
    private int currentScore;
    private int highScore = 0;
    private int totalScore;
    private int currentCheckPoint;

    private bool isGameStopped = false;

    void Awake()
    {
        Application.targetFrameRate = 60;

        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ResetValues();
}

    //score

    public int GetScore()
    {
        return currentScore;
    }

    public void SetScore(int score)
    {
        currentScore = score;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    public void SetTotalScore(int score)
    {
        totalScore = score;
    }

    public void HighScoreUpdate()
    {
        totalScore += currentScore;

        if (highScore < totalScore)
        {
            highScore = totalScore;
        }
    }

    public int GetHighScore()
    {
        return highScore;
    }

    //lives

    public int GetLives()
    {
        return lives;
    }

    public void SetLives(int lives)
    {
        this.lives = lives;
    }

    //checkpoint

    public int GetCheckPoint()
    {
        return currentCheckPoint;
    }

    public void checpointUpdate(int checkpointOffset)
    {
        currentCheckPoint += checkpointOffset;
    }

    //stop

    public void StopGame(bool stop)
    {
        isGameStopped = stop;
    }

    public bool IsGameStopped()
    {
        return isGameStopped;
    }

    //restart

    public void Death()
    {
        StartCoroutine(RestartRoutine(false));
    }

    public void RestartGame()
    {
        HighScoreUpdate();
        ResetValues();
        StartCoroutine(RestartRoutine(false));
    }

    public void GameOver()
    {
        HighScoreUpdate();
        GameOverScript.instance.GameOverSequance();
    }

    public void Exit()
    {
        ResetValues();
        StartCoroutine(RestartRoutine(true));
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }

    IEnumerator RestartRoutine(bool isExit)
    {
        if (isExit)
        {
            Transition.instance.EndTransition();
            yield return new WaitForSecondsRealtime(1.5f);
            SceneManager.LoadScene(0);
        }
        else
        {
            yield return new WaitForSecondsRealtime(1.5f);
            Transition.instance.EndTransition();
            yield return new WaitForSecondsRealtime(1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //level change

    public void NextLevel()
    {
        currentScore = 0;
        StartCoroutine(NextLevelRoutine());
    }

    IEnumerator NextLevelRoutine()
    {
        Transition.instance.EndTransition();
        yield return new WaitForSeconds(1.5f);
        currentScore = 0;
        currentCheckPoint = 1;
        SceneManager.LoadScene(++currentLevel);
    }

    //reset

    private void ResetValues()
    {
        totalScore = 0;
        currentCheckPoint = 1;
        lives = 3;
        currentScore = 0;
        totalScore = 0;
    }


}
