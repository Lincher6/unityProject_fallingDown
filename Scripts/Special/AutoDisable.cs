using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    [SerializeField]
    private float time = 3;

    void Start()
    {
        Invoke("Disable", time);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}
