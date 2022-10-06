using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    
    private int count;
    
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

        if (Mathf.Abs(rb.velocity.x) > 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);
    }

    public void Jump(bool jumpPressed)
    {
        if (jumpPressed && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, Vector2.up.y * jumpPower);
            groundController.onGround = false;
            audioSource.PlayOneShot(jumpSound);
        }
        
        anim.SetBool("isJumping", !onGround);
    }
    
    public void PrimaryAttack(bool primaryAttackPressed)
    {
        if (primaryAttackPressed)
        {
            GameObject newBomb = Instantiate(bomb, transform.position, Quaternion.identity);
            count += 1;
            newBomb.name += count.ToString();
            newBomb.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Door"))
        {
            DoorController dc = collider.GetComponent<DoorController>();
            if (dc.isItNextLevel || (!dc.isItNextLevel && dc.didExit))
                anim.SetTrigger("DoorIn");
        }
    }

    public void DeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
    
    public void RunResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
