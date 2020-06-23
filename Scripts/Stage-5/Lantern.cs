using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public static Lantern instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
