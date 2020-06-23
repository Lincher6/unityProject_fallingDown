using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBackground : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject rock;
    [SerializeField]
    private bool isLeft;
    [SerializeField]
    private int plane;

    [SerializeField]
    private float offsetX;
    private float posX;
    [SerializeField]
    private float offsetY = 15;
    private float posY;

    private bool isCloned = false;
    private int multiplier;

    void Start()
    {
        posY = offsetY;

        multiplier = isLeft ? -1 : 1;

        switch (plane)
        {
            case 1:
                posX = offsetX - (0 * multiplier);
                break;
            case 2:
                posX = offsetX - (0.5f * multiplier);
                break;
            case 3:
                posX = offsetX - (1 * multiplier);
                break;
        }
    }

    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime * SpeedManager.instance.speedMultiplier, 0);
        if (transform.position.y < 0f && !isCloned)
        {
            isCloned = true;
            Instantiate(rock, new Vector2(posX, posY), Quaternion.identity);
        }
        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }
}
