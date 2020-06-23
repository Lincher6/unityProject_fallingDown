using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X2Score : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UIManager.instance.ScoreMultiplierUp(1);
            Destroy(parent);
        }
    }
}
