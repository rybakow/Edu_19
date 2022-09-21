using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int maxHealth;
    public PlayerHealthBar playerHealthBar;
    public int currentHealth;
    private bool isALive;
    
    private void Awake()
    {
        currentHealth = maxHealth;
        isALive = true;
        playerHealthBar.SetMaxHealth(maxHealth);
    }

    public void CauseDamage(int damage)
    {
        currentHealth -= damage;
        playerHealthBar.SetHealth(currentHealth);
        
        isALive = currentHealth > 0 ? true : false;

        if (isALive)
            anim.SetTrigger("Hit");
        else
            anim.SetTrigger("Dead");
    }
}
