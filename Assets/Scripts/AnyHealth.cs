using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class AnyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public AnyHealthBar anyHealthBar;
    public int currentHealth;
    private bool isALive;
    
    private Animator anim;

    private Rigidbody2D rb;
    
    private void Awake()
    {
        currentHealth = maxHealth;
        isALive = true;
        anyHealthBar.SetMaxHealth(maxHealth);

        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    public void CauseDamage(int damage)
    {
        currentHealth -= damage;
        anyHealthBar.SetHealth(currentHealth);
        
        isALive = currentHealth > 0 ? true : false;
        
        if (isALive)
            anim.SetTrigger("Hit");
        else
        {
            anim.SetTrigger("Dead");
        }
    }
}
