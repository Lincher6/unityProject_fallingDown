using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public static Lava instance;

    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private GameObject fireSpark;
    [SerializeField]
    private GameObject lavaBall;
    [SerializeField]
    private GameObject preEruption;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime * SpeedManager.instance.speedMultiplier, 0), Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(fireSpark, collision.gameObject.transform.position, Quaternion.identity);
            PlayerMovement.instance.PlayerDeath();
        }
    }

    public void ShootLavaBall(float positionX)
    {
        StartCoroutine(ShootLavaBallRoutine(positionX));
    }

    IEnumerator ShootLavaBallRoutine(float positionX)
    {
        preEruption.SetActive(true);
        preEruption.transform.position = new Vector2(positionX, transform.position. y + 5);
        yield return new WaitForSeconds(2);
        Instantiate(lavaBall, new Vector2(positionX, transform.position.y + 5), Quaternion.identity);
    }


}
