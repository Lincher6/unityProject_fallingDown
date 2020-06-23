using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SppedUpOrDown : MonoBehaviour
{
    [SerializeField]
    private bool isDown;
    [SerializeField]
    private ParticleSystem speedUpEffect;
    [SerializeField]
    private ParticleSystem speedDownEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (isDown)
            {
                SpeedManager.instance.SpeedUp(-0.3f);
                Instantiate(speedDownEffect);
            } else
            {
                SpeedManager.instance.SpeedUp(0.3f);
                Instantiate(speedUpEffect);
            }

            Destroy(gameObject);
        }
    }
}
