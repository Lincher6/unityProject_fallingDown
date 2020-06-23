using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ShakeCamera(float duration, float power)
    {
        StartCoroutine(ShakeCameraRoutine(duration, power));
    }

    private IEnumerator ShakeCameraRoutine(float duration, float power)
    {
        Vector3 startPosition = transform.position;
        float timePassed = 0;

        while(timePassed < duration)
        {
            timePassed += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere * power;
            yield return null;
        }

        transform.position = startPosition;
    }
}
