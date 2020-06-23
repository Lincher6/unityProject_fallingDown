using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    private Rigidbody2D player;
    private Rigidbody2D canon;
    [SerializeField]
    private float power = 3;
    [SerializeField]
    private GameObject snowBall;
    [SerializeField]
    private GameObject shotEffect;
    [SerializeField]
    private GameObject shotPoint;

    private void Start()
    {
        player = PlayerMovement.instance.GetComponent<Rigidbody2D>();
        canon = GetComponent<Rigidbody2D>();
        StartCoroutine(ShotRoutine());
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 dir = (player.position - canon.position).normalized;
            float angle = Mathf.Atan2(dir.y + 0.1f, dir.x) * Mathf.Rad2Deg - 90f;
            GetComponent<Rigidbody2D>().rotation = angle;
        }
        
    }

    IEnumerator ShotRoutine()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 3 && player != null; i++)
        {
            
            Instantiate(snowBall, shotPoint.transform.position, transform.rotation);
            Instantiate(shotEffect, shotPoint.transform.position, transform.rotation);
            yield return new WaitForSeconds(4);
        }
    }
}
