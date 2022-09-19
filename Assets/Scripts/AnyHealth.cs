using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public AnyHealthBar anyHealthBar;
    public int currentHealth;
    private bool isALive;
    
    private void Awake()
    {
        currentHealth = maxHealth;
        isALive = true;
        anyHealthBar.SetMaxHealth(maxHealth);
    }

    public void CauseDamage(int damage)
    {
        currentHealth -= damage;
        anyHealthBar.SetHealth(currentHealth);
        
        isALive = currentHealth > 0 ? true : false;
    }
}
