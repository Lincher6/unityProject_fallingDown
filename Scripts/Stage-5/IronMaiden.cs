using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronMaiden : MonoBehaviour
{
    [SerializeField]
    private Sprite redButton;
    [SerializeField]
    private Sprite closedMaiden;
    [SerializeField]
    private SpriteRenderer maiden;
    [SerializeField]
    private GameObject deathZone;
    [SerializeField]
    private AudioSource audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = redButton;
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
            deathZone.SetActive(true);
            maiden.sprite = closedMaiden;
            audio.Play();
        }
    }
}
