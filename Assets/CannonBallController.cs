using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{
    public int damage;

    private float currentTime; 
        
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerHealth>().CauseDamage(damage);
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        
        if (currentTime >= 3f)
            Destroy(this.gameObject);
    }
}
