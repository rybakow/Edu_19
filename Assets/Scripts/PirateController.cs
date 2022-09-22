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

    private float prevXpostion;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        rb.velocity = new Vector2( speed, rb.velocity.y);
        
        if (Mathf.Abs(rb.velocity.x) > 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        
        if (prevXpostion == transform.position.x)
        {
            Debug.Log("velocity: " + rb.velocity + " and " + prevXpostion + " and " + transform.position.x);
            speed *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
            Jump();
        }
            
        
        prevXpostion = transform.position.x;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, Vector2.up.y * jumpPower);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
            if (!collision.gameObject.CompareTag("Player"))
                Jump();
    }
}
