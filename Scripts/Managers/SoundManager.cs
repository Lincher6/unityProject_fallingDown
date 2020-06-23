using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource BGM;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioSource soundFX_Looped;

    [SerializeField]
    private AudioClip gameOverClip, topFall, platformFlip, coolectiblesOver, bossMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartBGM()
    {
        BGM.Play();
    }

    public void StopBGM()
    {
        BGM.Stop();
    }

    public void GameOverSound()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }

    public void TopFallSound()
    {
        soundFX.clip = topFall;
        soundFX.Play();
    }

    public void PlatformFlipSound()
    {
        soundFX.clip = platformFlip;
        soundFX.Play();
    }

    public void coolectiblesOverSound()
    {
        StartCoroutine(coolectiblesOverSoundRoutine());
    }

    IEnumerator coolectiblesOverSoundRoutine()
    {
        soundFX_Looped.clip = coolectiblesOver;
        soundFX_Looped.Play();
        yield return new WaitForSeconds(1);
        soundFX_Looped.Stop();

    }

    public void BossMusic()
    {
        BGM.clip = bossMusic;
        BGM.Play();
    }

}
