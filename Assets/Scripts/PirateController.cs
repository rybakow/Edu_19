using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private float currentTime;
    private float lastPosition;

    [SerializeField] private GameObject firstPoint;
    [SerializeField] private GameObject secondPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        Run();

        currentTime += Time.deltaTime;

        if (currentTime >= 7f)
        {
            Jump();
            currentTime = 0f;
        }
    }
    

    private void Run()
    {
        rb.velocity = new Vector2( speed, rb.velocity.y);
        
        if (Mathf.Abs(rb.velocity.x) > 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, Vector2.up.y * jumpPower);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
            Jump();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("ReturnPoint"))
            TurnAround();
        
        if (collider.CompareTag("JumpPad"))
            Jump();
    }

    private void TurnAround()
    {
        speed *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
