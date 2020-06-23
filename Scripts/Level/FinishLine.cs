using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<MoveUpScaled>().enabled = false;
            GameManager.instance.StopGame(true);
            PlayerMovement.instance.StopPlayer();
            particle.SetActive(true);
            FinishScript.instance.FinishSequence();
        }
    }
}
