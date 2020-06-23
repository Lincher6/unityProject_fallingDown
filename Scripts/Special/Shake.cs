using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float duration;
    public float power;

    void Start()
    {
        CameraShake.instance.ShakeCamera(duration, power);
    }

}
