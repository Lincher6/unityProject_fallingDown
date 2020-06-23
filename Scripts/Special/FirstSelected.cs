using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelected : MonoBehaviour
{
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }
}
