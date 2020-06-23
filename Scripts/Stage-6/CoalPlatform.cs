using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalPlatform : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem smokeEffectt;
    [SerializeField]
    private GameObject fireEffectt;
    [SerializeField]
    private AudioSource roastSound;
    private float timer = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            smokeEffectt.Play();
            roastSound.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timer += Time.deltaTime;
            if (timer > 1.5f)
            {
                Instantiate(fireEffectt, collision.gameObject.transform.position, Quaternion.identity);
                PlayerMovement.instance.PlayerDeath();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timer = 0;
            smokeEffectt.Stop();
        }
    }
}
