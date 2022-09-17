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

    public CheckGround groundController;
    public bool onGround = true;

    public GameObject bomb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        onGround = groundController.onGround;
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
            rb.velocity = new Vector2(rb.velocity.x, Vector2.up.y * jumpPower);
            anim.SetTrigger("Jump");
            groundController.onGround = false;
        }
    }
    
    public void PrimaryAttack(bool primaryAttackPressed)
    {
        if (primaryAttackPressed)
        {
            GameObject newBomb = Instantiate(bomb, transform.position, Quaternion.identity);
            newBomb.SetActive(true);
        }
    }
    
    
}
