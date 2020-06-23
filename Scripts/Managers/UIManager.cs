using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject scoreMultiplierText;
    [SerializeField]
    private Text livesText;
    [SerializeField]
    private RectTransform playerDot;
    [SerializeField]
    private GameObject pauseIcon;
    [SerializeField]
    private GameObject[] androidControls;
    [SerializeField]
    private GameObject Finish;
    private int score = 0;
    private int scoreMultiplier = 1;
    private int lives = 3;
    private float startPositionY;
    private GameManager gm;

    void Awake()
    {
#if UNITY_ANDROID
        foreach (GameObject controll in androidControls) {
            controll.SetActive(true);
        }
#endif

        if (instance == null)
        {
            instance = this;
        }

        startPositionY = playerDot.anchoredPosition.y;
    }

    private void Start()
    {
        gm = GameManager.instance;
        score = gm.GetScore();
        lives = gm.GetLives();
        scoreText.text = score + "";
        livesText.text = "X " + lives;
    }

    public void scoreUpdate(int score)
    {
        score *= scoreMultiplier;
        scoreText.text = (this.score += score) + "";
        gm.SetScore(this.score);
    }

    public int GetScore()
    {
        return score;
    }

    public void lifeUpdate(int lifeOffset)
    {
        lives += lifeOffset;

        if (lives >= 0) {
            gm.SetLives(lives);
            livesText.text = "X " + lives;
            gm.Death();        
        }
        else
        {
            gm.GameOver();
        }
    }

    public void ScoreMultiplierUp(int power)
    {
        StartCoroutine(ScoreMultiplierUpRoutine(power));
    }

    IEnumerator ScoreMultiplierUpRoutine(int power)
    {
        scoreMultiplier += power;
        scoreMultiplierText.SetActive(true);
        yield return new WaitForSeconds(15);
        scoreMultiplierText.SetActive(false);
        scoreMultiplier = 1;
    }

    public void MovePlayerDotDown(int offSet)
    {
        playerDot.anchoredPosition = new Vector3(0, startPositionY - (offSet * 5),0);
    }
}
