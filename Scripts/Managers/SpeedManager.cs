using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager instance;
    public float speedMultiplier = 1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(SpeedGrowth());
    }

    private IEnumerator SpeedGrowth()
    {
        while (true)
        {
            yield return new WaitForSeconds(7);
            speedMultiplier += 0.1f;
            CheckSpeed();
        }
    }

    public void SpeedUp(float power)
    {
        speedMultiplier += power;
        CheckSpeed();

    }

    private void CheckSpeed()
    {
        if (speedMultiplier < 0.9f)
        {
            speedMultiplier = 0.9f;
        }
        if (speedMultiplier > 3)
        {
            speedMultiplier = 3;
        }
    }

    public void SpeedReset()
    {
        speedMultiplier = 1;
    }
}
