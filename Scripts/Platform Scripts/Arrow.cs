using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private Animator animArrow;
    [SerializeField]
    private Animator animPlatform;
    [SerializeField]
    private new BoxCollider2D collider2D;

    private bool isFlipped = false;

    private void Update()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Vector2 pos = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
            if (hitInfo.transform.gameObject.CompareTag("Arrow") && !isFlipped)
            {
                isFlipped = true;
                Flip();
            }
        }
#else
        if (Input.GetAxisRaw("Vertical") < -0.9f)
        {
            animArrow.SetBool("fillUp", true);
        }

        else
        {
            animArrow.SetBool("fillUp", false);
        }
#endif
    }

    public void Flip()
    {
        StartCoroutine(FlipRoutine());
    }

    private IEnumerator FlipRoutine()
    {
        collider2D.enabled = false;
        animPlatform.SetTrigger("flip");
        SoundManager.instance.PlatformFlipSound();
        yield return new WaitForSeconds(1);
        collider2D.enabled = true;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
}
