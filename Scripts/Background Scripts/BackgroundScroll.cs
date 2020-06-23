using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private float _scrollSpeed = 0.3f;
    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        Vector2 offSet = meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");
        offSet.y += _scrollSpeed * Time.deltaTime * SpeedManager.instance.speedMultiplier;
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offSet);
    }
}
