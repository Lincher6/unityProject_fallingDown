using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public static GameOverScript instance;

    [SerializeField]
    private GameObject fade;
    [SerializeField]
    private GameObject splatter;
    [SerializeField]
    private GameObject gameOverText;
    [SerializeField]
    private GameObject buttonPanel;
    [SerializeField]
    private GameObject playerHurt;
    [SerializeField]
    private GameObject playerDead;
    [SerializeField]
    private GameObject playerAlive;
    [SerializeField]
    private GameObject totalScore;
    [SerializeField]
    private TextMeshProUGUI totalScoreNumber;
    [SerializeField]
    private GameObject highScore;
    [SerializeField]
    private TextMeshProUGUI highScoreNumber;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GameOverSequance()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        totalScoreNumber.text = GameManager.instance.GetTotalScore() + "";
        highScoreNumber.text = GameManager.instance.GetHighScore() + "";
        yield return new WaitForSeconds(1);
        fade.SetActive(true);
        yield return new WaitForSeconds(1);
        SoundManager.instance.StopBGM();
        splatter.SetActive(true);
        yield return new WaitForSeconds(1);
        gameOverText.SetActive(true);
        totalScore.SetActive(true);
        highScore.SetActive(true);
        buttonPanel.SetActive(true);
    }

    public void Restart()
    {
        playerHurt.SetActive(false);
        playerAlive.SetActive(true);
        GameManager.instance.RestartGame();
    }

    public void Exit()
    {
        playerHurt.SetActive(false);
        playerDead.SetActive(true);
        GameManager.instance.Exit();
    }
}
