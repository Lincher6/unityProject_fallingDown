using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effect;
    [SerializeField]
    private GameObject text;
    private bool isActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isActivated)
        {
            Instantiate(effect);
            text.SetActive(true);
            isActivated = true;
            GameManager.instance.checpointUpdate(1);
        }
    }
}
