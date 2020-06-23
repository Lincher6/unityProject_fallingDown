using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGaizerPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject lava;
    [SerializeField]
    private GameObject gaizer;
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private GameObject killZone;
    [SerializeField]
    private AudioSource audio;
    private bool isActivated = false;

    private void Update()
    {
        if (isActivated)
        {
            platform.gameObject.transform.Translate(new Vector3(0 , 1 * Time.deltaTime, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isActivated)
        {
            StartCoroutine(Eruption());
        }
    }

    IEnumerator Eruption()
    {
        Destroy(lava.gameObject);
        gaizer.SetActive(true);
        isActivated = true;
        audio.Play();
        yield return new WaitForSeconds(1.5f);
        killZone.SetActive(true);
    }
}
