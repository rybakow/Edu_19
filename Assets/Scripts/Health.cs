using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    public HealthBar healthBar;
    public int currentHealth;
    private bool isALive;
    
    private void Awake()
    {
        currentHealth = maxHealth;
        isALive = true;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void CauseDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        isALive = currentHealth > 0 ? true : false;
    }
}
