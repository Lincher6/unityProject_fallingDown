using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public static PowerUps instance;
    [SerializeField]
    private GameObject umbrella;
    [SerializeField]
    private GameObject weight;
    [SerializeField]
    private GameObject torch;
    private Rigidbody2D rb;
    private float initialGravity;
    private float lastPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        rb = GetComponent<Rigidbody2D>();
        initialGravity = rb.gravityScale;

        lastPos = transform.position.y;
    }

    public void LowGravity(bool isLow)
    {
        StartCoroutine(GravityRoutine(isLow));
    }

    IEnumerator GravityRoutine(bool isLow)
    {
        if (isLow)
        {
            umbrella.SetActive(true);
            Coroutine routine =  StartCoroutine(LowGravityRoutine());
            yield return new WaitForSeconds(14);
            SoundManager.instance.coolectiblesOverSound();
            yield return new WaitForSeconds(1);
            StopCoroutine(routine);
            yield return new WaitForSeconds(0.1f);
            rb.gravityScale = initialGravity;
            umbrella.SetActive(false);
        } 
        else
        {
            weight.SetActive(true);
            rb.gravityScale = 2;
            yield return new WaitForSeconds(14);
            SoundManager.instance.coolectiblesOverSound();
            yield return new WaitForSeconds(1);
            rb.gravityScale = initialGravity;
            weight.SetActive(false);
        }
    }

    IEnumerator LowGravityRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            if (transform.position.y < lastPos)
            {
                rb.gravityScale = 0.1f;
            }
            else
            {
                rb.gravityScale = initialGravity;
            }

            lastPos = transform.position.y;
        }
    }

    public void Torch()
    {
        StartCoroutine(TourchRoutine());
    }

    IEnumerator TourchRoutine()
    {
        torch.SetActive(true);
        yield return new WaitForSeconds(14);
        SoundManager.instance.coolectiblesOverSound();
        yield return new WaitForSeconds(1);
        torch.SetActive(false);
    }
}
