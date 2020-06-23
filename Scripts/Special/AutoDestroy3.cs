using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy3 : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3);
    }
}
