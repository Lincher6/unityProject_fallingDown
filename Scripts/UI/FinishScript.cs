using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public static FinishScript instance;

    [SerializeField]
    private GameObject fade;
    [SerializeField]
    private GameObject normalScoreText;
    [SerializeField]
    private TextMeshProUGUI normalScoreNumber;
    [SerializeField]
    private GameObject x1;
    [SerializeField]
    private GameObject speedMultiplierText;
    [SerializeField]
    private TextMeshProUGUI speedNumber;
    [SerializeField]
    private GameObject finalScore;

    [SerializeField]
    private GameObject totalScoreText;
    [SerializeField]
    private TextMeshProUGUI totalScoreNumber;
    [SerializeField]
    private AudioSource scoreFillUp;

    [SerializeField]
    private GameObject continueButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void FinishSequence()
    {
        StartCoroutine(FinishRoutine());
    }

    IEnumerator FinishRoutine()
    {
        int totalScore = GameManager.instance.GetTotalScore();
        int score = UIManager.instance.GetScore();
        float speed = SpeedManager.instance.speedMultiplier;
        int levelScore = (int)(score * speed);

        yield return new WaitForSeconds(3);
        fade.SetActive(true);
        yield return new WaitForSeconds(1);
        normalScoreNumber.text = score + "";
        normalScoreText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        x1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        speedNumber.text = string.Format("{0:f2}", speed);
        speedMultiplierText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        finalScore.GetComponent<TextMeshProUGUI>().text = levelScore + "";
        finalScore.SetActive(true);

        yield return new WaitForSeconds(2);
        totalScoreText.SetActive(true);
        totalScoreNumber.text = totalScore + " + " + levelScore;
        yield return new WaitForSeconds(1);
        scoreFillUp.Play();

        while (levelScore > 0)
        {
            totalScore += 10;
            levelScore -= 10;
            totalScoreNumber.text = totalScore + " + " + levelScore;
            yield return new WaitForSeconds(0.01f);
        }

        scoreFillUp.Stop();
        totalScore += levelScore % 10;
        GameManager.instance.SetTotalScore(totalScore);
        totalScoreNumber.text = totalScore + "";

        continueButton.SetActive(true);
    }
}
