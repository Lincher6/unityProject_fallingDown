using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private float horizontalInput = 0;
    private bool jumpInput = false;
    private bool canJump = false;
    private bool isStunned = false;
    private bool isShield = false;
#if UNITY_ANDROID
    private bool tapInput;
    private Touch touch;
    private int touchCount = 0;
    private float doubleTapTimer = 0;
    private float doubleTapOffset = 0.3f;
#endif


    private float minX = -2.4f, maxX = 2.4f, minY = -6;
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 1f;
    private float initialSpeed;
    [SerializeField]
    private float jumpForce = 7;
    private float initialJumpForce;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private ParticleSystem landEffect;
    [SerializeField]
    private AudioSource landSound;
    [SerializeField]
    private Animator anim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        rb = transform.GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        initialJumpForce = jumpForce;
    }

    void Update()
    {
        if (transform.position.y < minY)
        {
            PlayerDeath();
        }

#if UNITY_ANDROID
#else
            horizontalInput = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && canJump)
            {
                jumpInput = true;
            }
#endif
    }

    private void FixedUpdate()
    {
        Vector3 bounds = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.x);
        transform.position = bounds;

        if (!isStunned)
        {
            Move();
        }
    }

    private void Move()
    {

#if UNITY_ANDROID

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector2 tapPoint = touch.position;
            tapPoint = Camera.main.ScreenToWorldPoint(tapPoint);
            if (tapPoint.x > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else if (tapPoint.x < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }

            for (var i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).tapCount == 2)
                {
                    if (canJump)
                    {
                        Invoke("Jump", 0.05f);
                        anim.SetTrigger("isJump");
                        canJump = false;
                        touchCount = 0;
                    }
                }
            }

        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
#else
        //transform.Translate(horizontalInput * speed * Time.deltaTime, 0, 0, Space.World);
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (jumpInput)
        {
            Invoke("Jump", 0.05f);
            anim.SetTrigger("isJump");
            canJump = false;
            jumpInput = false;
        }
#endif
    }

    public void PlatformMove(float x)
    {
        transform.Translate(x * speed * Time.deltaTime, 0, 0, Space.World);
    }

    public void PlayerDeath()
    {
        GameManager.instance.StopGame(true);
        CameraShake.instance.ShakeCamera(0.3f, 0.1f);
        Instantiate(particle, transform.position, Quaternion.identity);
        UIManager.instance.lifeUpdate(-1);
        Destroy(gameObject);
    }

    public void LunchUp(int power)
    {
        rb.velocity =  new Vector2(rb.velocity.x, power);
    }

    public void SlowDown(int time, float power)
    {
        StartCoroutine(SlowDownRoutine(time, power));
    }

    private IEnumerator SlowDownRoutine(int time, float power)
    {
        speed /= power;
        yield return new WaitForSeconds(time);
        speed *= power;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(0, jumpForce);
    }

    public void Land()
    {
        anim.SetTrigger("land");
        Instantiate(landEffect, new Vector2(transform.position.x, transform.position.y - 0.3f), Quaternion.identity);
        landSound.Play();
    }

    public void SetCanJump(bool canJump)
    {
        this.canJump = canJump;
    }

    public void Stun()
    {
        StartCoroutine(StunCourutine());
    }

    public bool IsShield()
    {
        return isShield;
    }

    public void SetShield(bool shieldOn)
    {
        if (shieldOn)
        {
            isShield = true;
            PlayerVisual.instance.ShieldOn();
        }
        else
        {
            isShield = false;
            PlayerVisual.instance.ShieldOff();
        }
    }

    IEnumerator StunCourutine()
    {
        isStunned = true;
        PlayerVisual.instance.DizzyOn();
        yield return new WaitForSeconds(1.5f);
        PlayerVisual.instance.DizzyOff();
        isStunned = false;
    }

    public void StopPlayer()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetJumpForce(float force)
    {
        this.jumpForce = force;
    }

    public float GetInitialSpeed()
    {
        return initialSpeed;
    }

    public float GetInitialJumpForce()
    {
        return initialJumpForce;
    }



}
