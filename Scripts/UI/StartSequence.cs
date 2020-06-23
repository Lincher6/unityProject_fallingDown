using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartSequence : MonoBehaviour
{
    public static StartSequence instance;

    [SerializeField]
    private GameObject one;
    [SerializeField]
    private GameObject two;
    [SerializeField]
    private GameObject three;
    [SerializeField]
    private GameObject go;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartCountdown()
    {
        Time.timeScale = 0;
        GameManager.instance.StopGame(true);
        StartCoroutine(StartSequenceRoutine());
    }

    private IEnumerator StartSequenceRoutine()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        three.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        two.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        one.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        SoundManager.instance.StartBGM();
        GameManager.instance.StopGame(false);
        go.SetActive(true);

    }
}
