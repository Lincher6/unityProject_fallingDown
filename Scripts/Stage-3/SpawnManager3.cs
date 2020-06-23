using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public static SpawnManager3 instance;

    public GameObject steam;
    public GameObject standartPlatfrom;
    public GameObject movingPlatform;
    public GameObject electroPlatfrom;
    public GameObject heavyPlatform;
    public GameObject[] saw;
    public GameObject spark;
    public GameObject top;
    public GameObject boss;
    public GameObject caution;
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
    private bool isBossKilled = false;
    private GameManager gm;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

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
            case 4:
                levelPart = 150;
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
                StartCoroutine(SawRoutine());
                isFirstPart = true;
            }

            if (i == 94)
            {
                Instantiate(checkPoint, transform.position, Quaternion.identity);
            }

            if (i >= 95 && !isSecondPart)
            {
                StartCoroutine(SparkRoutine());
                isSecondPart = true;
            }

            if (i == 145)
            {
                Instantiate(checkPoint, transform.position, Quaternion.identity);
            }

            SpawnPlatform();
            SpawnStar();

            yield return new WaitForSeconds(spawnTimer / SpeedManager.instance.speedMultiplier);
            i++;

            if (i % 3 == 0)
            {
                Instantiate(steam, new Vector2(Random.Range(minX, manX), transform.position.y + 10), Quaternion.Euler(-90, Random.Range(-45, 45), 0));
            }
        }

        if (!gm.IsGameStopped())
        {
            StopAllCoroutines();
            StartCoroutine(BossRoutine());
        }

    }

    private IEnumerator SparkRoutine()
    {
        yield return new WaitForSeconds(4);
        while (!gm.IsGameStopped())
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(spark, new Vector2(-1.3f, transform.position.y), Quaternion.identity);
            }
            else
            {
                Instantiate(spark, new Vector2(1.3f, transform.position.y), Quaternion.identity);
            }
            yield return new WaitForSeconds(15);
        }
    }

    private IEnumerator SawRoutine()
    {
        yield return new WaitForSeconds(4);
        while (!gm.IsGameStopped())
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(saw[0], new Vector2(-2.8f, transform.position.y), Quaternion.identity);
            }
            else
            {
                Instantiate(saw[1], new Vector2(2.8f, transform.position.y), Quaternion.identity);
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
            currentPlatform = Instantiate(electroPlatfrom, spawnPosition, Quaternion.identity).GetComponent<PlatformInfo>();
        }
        else if (Random.Range(0, 2) == 0)
        {
            currentPlatform = Instantiate(movingPlatform, spawnPosition, Quaternion.identity).GetComponent<PlatformInfo>();
        }
        else if (Random.Range(0, 2) == 0 && !currentPlatform.isBreakable)
        {
            currentPlatform = Instantiate(heavyPlatform, spawnPosition, Quaternion.Euler(0, 0, Random.Range(-7, 7))).GetComponent<PlatformInfo>();
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
            Instantiate(powerUps[Random.Range(0, 3)], new Vector2(Random.Range(minX, manX), transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(20, 30));
        }


    }

    IEnumerator BossStartRoutine()
    {
        yield return new WaitForSeconds(3);
        top.GetComponent<Animator>().SetTrigger("moveUp");
        Instantiate(caution);
        yield return new WaitForSeconds(1);
        SpeedManager.instance.SpeedReset();
        SoundManager.instance.StopBGM();
        yield return new WaitForSeconds(3);
        SoundManager.instance.BossMusic();
        Instantiate(boss);
    }

    IEnumerator BossRoutine()
    {
        StartCoroutine(BossStartRoutine());

        while (!isBossKilled)
        {
            if (!IsPossitionSet())
            {
                continue;
            }

            currentPlatform = Instantiate(standartPlatfrom, spawnPosition, Quaternion.identity).GetComponent<PlatformInfo>();
            currentPosition = currentPlatform.gameObject.transform.position;
            yield return new WaitForSeconds(spawnTimer / SpeedManager.instance.speedMultiplier);
        }

        if (!gm.IsGameStopped())
        {
            Instantiate(finishLine, transform.position, Quaternion.identity);
        }
    }

    public void BossKill()
    {
        isBossKilled = true;
    }
}
