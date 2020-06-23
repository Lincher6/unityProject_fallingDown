using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpUnscaled : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float boundY = 7f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        if (transform.position.y > boundY) Destroy(gameObject);
    }
}
