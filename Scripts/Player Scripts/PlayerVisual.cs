using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    public static PlayerVisual instance;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite normal;
    [SerializeField]
    private Sprite fall;
    [SerializeField]
    private Sprite stunned;
    [SerializeField]
    private GameObject dizzy;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject shieldDownEffect;

    private float lastPositionY;
    private bool isFalling = false;
    private bool isStunned = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        lastPositionY = transform.position.y;
    }

    void FixedUpdate()
    {
        if (lastPositionY > transform.position.y)
        {
            if (!isFalling && !isStunned)
            {
                isFalling = true;
                spriteRenderer.sprite = fall;
            }
        }
        else if (!isStunned)
        {
            isFalling = false;
            spriteRenderer.sprite = normal;
        }

        lastPositionY = transform.position.y;
    }

    public void DizzyOn()
    {
        dizzy.SetActive(true);
        isStunned = true;
        spriteRenderer.sprite = stunned;
    }

    public void DizzyOff()
    {
        dizzy.SetActive(false);
        isStunned = false;
        spriteRenderer.sprite = normal;
    }

    public void ShieldOn()
    {
        shield.SetActive(true);
    }

    public void ShieldOff()
    {
        shield.SetActive(false);
        Instantiate(shieldDownEffect, transform.position, Quaternion.identity);
    }

}
