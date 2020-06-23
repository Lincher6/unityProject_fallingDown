using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 10);
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
