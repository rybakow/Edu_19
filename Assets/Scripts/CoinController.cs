using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Rigidbody2D rb;
   
    public AudioSource audioSource;
    public AudioClip coinGotten;

    public GameObject partical;

    private bool gotten;
    private float currentTime;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            audioSource.PlayOneShot(coinGotten);
            partical.SetActive(false);
            GameState.coinsCount += 1;
            rb.velocity = Vector2.up * 5f;
            gotten = true;
        }
    }

    private void Update()
    {
        if (gotten)
        {
            currentTime += Time.deltaTime;
            
            if (currentTime > 1f)
                Destroy(this.gameObject);
        }
            
    }
}
