using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject charge;
    private bool isActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isActivated)
        {
            isActivated = true;
            charge.SetActive(true);
        }
    }
}
