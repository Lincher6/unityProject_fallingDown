using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSpikes : MonoBehaviour
{
    public static TopSpikes instance;

    [SerializeField]
    private GameObject dangerZone;
    private float dangerZonePosition = 3.5f;
    [SerializeField]
    private Animator anim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.instance.PlayerDeath();
        }
    }

    public void FallSequance()
    {
        StartCoroutine(FallSequanceRoutine());
    }

    private IEnumerator FallSequanceRoutine()
    {
        Instantiate(dangerZone, new Vector3(0, dangerZonePosition, 0), Quaternion.identity);
        yield return new WaitForSeconds(3);
        anim.SetTrigger("fall");
        SoundManager.instance.TopFallSound();
        CameraShake.instance.ShakeCamera(0.5f, 0.1f);
    }
}
