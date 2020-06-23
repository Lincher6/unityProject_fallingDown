using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSpikes_Stage2 : MonoBehaviour
{
    public static TopSpikes_Stage2 instance;

    [SerializeField]
    private Animator[] animations;
    [SerializeField]
    private AudioSource audio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void SpikeFall()
    {
        animations[Random.Range(0, animations.Length)].SetTrigger("isFall");
        audio.Play();
    }
}
