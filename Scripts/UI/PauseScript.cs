using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static PauseScript instance;

    [SerializeField]
    private GameObject fade;
    [SerializeField]
    private GameObject pauseIcon;
    [SerializeField]
    private GameObject checkIcon;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (!GameManager.instance.IsGameStopped())
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                fade.SetActive(false);
                pauseIcon.SetActive(false);
                checkIcon.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
                fade.SetActive(true);
                pauseIcon.SetActive(true);
            }
        }
    }

    public void Exit()
    {
        pauseIcon.SetActive(false);
        checkIcon.SetActive(true);
    }

    public void ExitYes()
    {
        GameManager.instance.ApplicationQuit();
    }

    public void ExitNo()
    {
        checkIcon.SetActive(false);
        pauseIcon.SetActive(true);
    }

    public void Resume()
    {
        Pause();
    }
}
