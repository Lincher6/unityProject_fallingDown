using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject bigExplosion;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private GameObject smoke1;
    [SerializeField]
    private GameObject smoke2;
    [SerializeField]
    private Animator anim;

    private int hp = 8;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.instance.LunchUp(12);
            Instantiate(explosion, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            HPDown();
        }
    }

    private void HPDown()
    {
        hp--;

        if (hp == 5)
        {
            smoke1.SetActive(true);
        }
        if (hp == 2)
        {
            smoke2.SetActive(true);
        }

        if (hp <= 0)
        {
            StartCoroutine(BossDeathRoutine());
        }
    }

    IEnumerator BossDeathRoutine()
    {
        anim.SetTrigger("stop");

        for (int i = 0; i < 10; i++)
        {
            Instantiate(explosion, new Vector2(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-1, 2)), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }

        SpawnManager3.instance.BossKill();
        SoundManager.instance.StopBGM();
        Instantiate(bigExplosion, transform.position, Quaternion.identity);
        Destroy(boss.gameObject);
    }
}
