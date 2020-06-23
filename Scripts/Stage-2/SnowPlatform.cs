using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPlatform : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite newSprite;
    [SerializeField]
    private GameObject effect;

    private bool isLanded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isLanded)
        {
            spriteRenderer.sprite = newSprite;
            effect.SetActive(true);
        }
    }
}
