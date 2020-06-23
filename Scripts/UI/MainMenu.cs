using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScore;

    void Start()
    {
        highScore.text = "High Score : " + GameManager.instance.GetHighScore();
    }

}
