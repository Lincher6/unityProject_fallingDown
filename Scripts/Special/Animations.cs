using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public bool isBlob;
    public bool isLeftRight;

    [SerializeField]
    private Animator anim;


    void Start()
    {
        if (isBlob)
        {
            anim.SetBool("isBlob", true);
        }

        if (isLeftRight)
        {
            anim.SetBool("isLeftRight", true);
        }
    }

    private void OnEnable()
    {
        if (isBlob)
        {
            anim.SetBool("isBlob", true);
        }

        if (isLeftRight)
        {
            anim.SetBool("isLeftRight", true);
        }
    }
}
