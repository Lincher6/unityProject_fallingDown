using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float boundY = 6f;
    private bool isFall = false;
    [SerializeField]
    private Transform platfrom;
    [SerializeField]
    private GameObject particleLeft;
    [SerializeField]
    private GameObject particleRight;
    [SerializeField]
    private Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isFall = true;
            particleLeft.SetActive(true);
            particleRight.SetActive(true);
            anim.SetTrigger("fall");
        }
    }

    void FixedUpdate()
    {
        if (isFall)
        {
            platfrom.Translate(new Vector3(0, -speed * Time.deltaTime, 0), Space.World);
            if (platfrom.position.y < -boundY) Destroy(platfrom.gameObject);
        }
        else
        {
            platfrom.Translate(new Vector3(0, speed * Time.deltaTime * SpeedManager.instance.speedMultiplier, 0), Space.World);
            if (platfrom.position.y > boundY) Destroy(platfrom.gameObject);
        }
    }
}
