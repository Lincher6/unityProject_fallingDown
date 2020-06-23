using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    public static Darkness instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
