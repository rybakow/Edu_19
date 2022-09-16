using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool onGround;
    
    public Transform groundCheck;
    public float checkRadius = 0.5f;
    public LayerMask ground;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckingGround();
    }


    public void Run(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (rb.velocity.x < 0f)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }

    public void Jump(bool jumpPressed)
    {
        if (jumpPressed && onGround)
        {
            Debug.Log("Jump");
            rb.velocity = new Vector2(rb.velocity.x, Vector2.up.y * jumpPower);
        }
    }
    
    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + " " + collision.gameObject.layer);
    }
}
