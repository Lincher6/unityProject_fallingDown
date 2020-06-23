using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : MonoBehaviour
{
    private Animator darknessAnim;
    private Animator lanternAnim;
    private bool isPressed = false;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private SpriteRenderer platform;
    [SerializeField]
    private Sprite buttonOn;

    private void Start()
    {
        darknessAnim = GameObject.Find("Darkness").GetComponent<Animator>();
        lanternAnim = GameObject.Find("Lantern").GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isPressed)
        {
            isPressed = true;
            audio.Play();
            darknessAnim.SetTrigger("light");
            lanternAnim.SetTrigger("light");
            platform.sprite = buttonOn;
        }
    }
}
