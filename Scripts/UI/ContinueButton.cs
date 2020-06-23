using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    private bool isPreesed = false;

    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Submit") || Input.touchCount > 0)
        {
            if (!isPreesed)
            {
                isPreesed = true;
                GameManager.instance.NextLevel();
            }
        }
    }
}
