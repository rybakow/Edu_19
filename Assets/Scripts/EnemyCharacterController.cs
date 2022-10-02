using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyCharacterController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private float currentTime;
    private float lastPosition;

    public Transform target;

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
        if (target != null)
            TurnAround(false, target.position.x - transform.position.x);

        rb.velocity = new Vector2(speed, rb.velocity.y);
        
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
            TurnAround(true);

        if (collider.CompareTag("JumpPad"))
            Jump();
    }
    
    private void TurnAround(bool isTurnPoint, float directionDelta = 0f)
    {
        if (isTurnPoint)
        {
            speed *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        else
        {
            if (directionDelta > 0)
            {
                speed = 1;
                spriteRenderer.flipX = false;
            }
            else
            {
                speed = -1;
                spriteRenderer.flipX = true;
            }  
        }
            
    }
    
    public void StopAttack()
    {
        anim.SetBool("isAttacking", false);
    }

    public void DestroyCharacter()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
