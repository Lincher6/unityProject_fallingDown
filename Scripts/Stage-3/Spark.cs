using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    void Update()
    {
        if (transform.position.y > -3)
        {
            anim.SetTrigger("spark");
        }
    }
}
