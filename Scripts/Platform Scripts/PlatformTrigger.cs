using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;
    private bool isActive = false;

    private void Start()
    {
        arrow.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isActive && transform.position.y > -2)
        {
            arrow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            isActive = false;
            arrow.SetActive(false);
        }
    }
}
