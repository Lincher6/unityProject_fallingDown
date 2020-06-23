using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private float speed = 1;
    private Vector2 moveVector;
    private Vector2 lanternPosition;
    private Animator lanternAnim;
    private Animator darknessAnim;

    [SerializeField]
    private GameObject ghostDeathEffect;

    void Start()
    {
        lanternPosition = Lantern.instance.transform.position;
        moveVector = (new Vector2(lanternPosition.x, lanternPosition.y - 1) - (Vector2)transform.position).normalized;

        lanternAnim = Lantern.instance.GetComponent<Animator>();
        darknessAnim = Darkness.instance.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            lanternAnim.SetTrigger("dark");
            darknessAnim.SetTrigger("dark");
            Instantiate(ghostDeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.tag == "Player")
        {
            PlayerMovement.instance.LunchUp(7);
            Instantiate(ghostDeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(moveVector * speed * Time.deltaTime);
    }
}
