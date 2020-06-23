using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public static Transition instance;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private new AudioSource audio;
    [SerializeField]
    private AudioClip appear, fade;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void EndTransition()
    {
        anim.SetTrigger("end");
    }

    public void AppearSound()
    {
        audio.clip = appear;
        audio.Play();
    }

    public void FadeSound()
    {
        audio.clip = fade;
        audio.Play();
    }
}
