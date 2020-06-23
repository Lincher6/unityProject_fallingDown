using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpScaled : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float boundY = 7f;

    private void Start()
    {
        StartCoroutine(CheckBorder())
;    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime * SpeedManager.instance.speedMultiplier, 0), Space.World);
    }

    IEnumerator CheckBorder()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (transform.position.y > boundY || transform.position.y < -boundY) Destroy(gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
