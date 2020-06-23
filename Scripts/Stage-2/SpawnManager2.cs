﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    public GameObject standartPlatfrom;
    public GameObject spikePlatfrom;
    public GameObject breakablePlatfrom;
    public GameObject[] icePlatform;
    public GameObject canon;
    public GameObject speedUp;
    public GameObject speedDown;
    public GameObject[] powerUps;
    public GameObject checkPoint;
    public GameObject finishLine;
    public GameObject star;

    private float spawnTimer = 2;
    private PlatformInfo currentPlatform;
    private Vector2 currentPosition;
    private float minX = -2f;
    private float manX = 2f;
    private Vector2 spawnPosition;
    private bool isPlatformUnder = false;
    private int levelPart;
    private bool isFirstPart = false;
    private bool isSecondPart = false;
    private GameManager gm;

    void Start()
    {
        gm = GameManager.instance;

        switch (GameManager.instance.GetCheckPoint())
        {
            case 1:
                levelPart = 0;
                break;
            case 2:
                levelPart = 50;
                break;
            case 3:
                levelPart = 95;
                break;
        }

        currentPlatform = Instantiate(standartPlatfrom, new Vector2(0, -4), Quaternion.identity).GetComponent<PlatformInfo>();
        currentPosition = currentPlatform.gameObject.transform.position;
        StartSequence.instance.StartCountdown();
        StartCoroutine(PlatformSpawnerRoutine_1());
        StartCoroutine(ColletiblesRoutine());
        StartCoroutine(PowerUpRoutine());
    }

    private IEnumerator PlatformSpawnerRoutine_1()
    {
        yield return new WaitForSeconds(1);

        for (int i = levelPart; i < 150 && !gm.IsGameStopped();)
        {
            if (!IsPossitionSet())
            {
                continue;
            }

            UIManager.instance.MovePlayerDotDown(i);

            if (i == 49)
            {
                Instantiate(checkPoint, transform.position, Quaternion.identity);
            }

            if (i >= 50 && !isFirstPart)
            {
                StartCoroutine(CanonRoutine());
                isFirstPart = true;
            }

            if (i == 94)
            {
                Instantiate(checkPoint, transform.position, Quaternion.identity);
            }

            if (i >= 95 && !isSecondPart)
            {
                StartCoroutine(TopFallingRoutine());
                isSecondPart = true;
            }

            SpawnPlatform();
            SpawnStar();

            yield return new WaitForSeconds(spawnTimer / SpeedManager.instance.speedMultiplier);
            i++;
        }

        if (!gm.IsGameStopped())
        {
            Instantiate(finishLine, transform.position, Quaternion.identity);
        }

    }

    private IEnumerator TopFallingRoutine()
    {
        yield return new WaitForSeconds(4);
        while (!gm.IsGameStopped())
        {
            TopSpikes_Stage2.instance.SpikeFall();
            yield return new WaitForSeconds(6);
        }
    }

    private IEnumerator CanonRoutine()
    {
        yield return new WaitForSeconds(4);
        while (!gm.IsGameStopped())
        {
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(canon, new Vector2(-1.8f, transform.position.y), Quaternion.identity);
            }
            else
            {
                Instantiate(canon, new Vector2(1.8f, transform.position.y), Quaternion.identity);
            }
            yield return new WaitForSeconds(15);
        }
    }

    private IEnumerator ColletiblesRoutine()
    {
        yield return new WaitForSeconds(12);
        bool isSpeedUp = false;
        while (!gm.IsGameStopped())
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(speedDown, new Vector2(Random.Range(minX, manX), transform.position.y), Quaternion.identity);
                isSpeedUp = false;
            }
            else if (!isSpeedUp)
            {
                Instantiate(speedUp, new Vector2(Random.Range(minX, manX), transform.position.y), Quaternion.identity);
                isSpeedUp = true;
            }
            else
            {
                continue;
            }

            yield return new WaitForSeconds(Random.Range(13, 25));
        }

    }

    private void SpawnPlatform()
    {
        if (Random.Range(0, 2) == 0)
        {
            currentPlatform = Instantiate(standartPlatfrom, spawnPosition, Quaternion.identity).GetComponent<PlatformInfo>();
        }
        else if (Random.Range(0, 4) == 0 && !currentPlatform.isSpike && !currentPlatform.isBreakable)
        {
            currentPlatform = Instantiate(spikePlatfrom, spawnPosition, Quaternion.identity).GetComponent<PlatformInfo>();
        }
        else if (Random.Range(0, 2) == 0)
        {
            currentPlatform = Instantiate(icePlatform[Random.Range(0, 2)], spawnPosition, Quaternion.identity).GetComponent<PlatformInfo>();
        }
        else if (Random.Range(0, 2) == 0 && !currentPlatform.isBreakable)
        {
            currentPlatform = Instantiate(breakablePlatfrom, spawnPosition, Quaternion.identity).GetComponent<PlatformInfo>();
        }
        else
        {
            currentPlatform = Instantiate(standartPlatfrom, spawnPosition, Quaternion.identity).GetComponent<PlatformInfo>();
        }

        currentPosition = currentPlatform.gameObject.transform.position;
    }

    private void SpawnStar()
    {
        if (Random.Range(0, 2) == 0 && !currentPlatform.isSpike)
        {
            Instantiate(star, new Vector2(currentPosition.x, currentPosition.y + 0.5f), Quaternion.identity);
        }

        if (Random.Range(0, 2) == 0 && !currentPlatform.isSpike)
        {
            Instantiate(star, new Vector2(Random.Range(minX, manX), currentPosition.y + 1f), Quaternion.identity);
        }
    }

    private bool IsPossitionSet()
    {
        spawnPosition = new Vector2(Random.Range(minX, manX), transform.position.y);

        if (spawnPosition.x > currentPosition.x - 0.6f && spawnPosition.x < currentPosition.x + 0.6f)
        {
            if (isPlatformUnder)
            {
                return false;
            }
            else
            {
                isPlatformUnder = true;
                return true;
            }
        }

        return true;
    }

    private IEnumerator PowerUpRoutine()
    {
        yield return new WaitForSeconds(7);
        while (!gm.IsGameStopped())
        {
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], new Vector2(Random.Range(minX, manX), transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(20, 30));
        }


    }
}