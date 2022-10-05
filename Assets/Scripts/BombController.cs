using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public int timeToExploison;
    [SerializeField] private PointEffector2D bomb;
    private Animator anim;
    private float currentTime;
    private BombDamageController bombDamageController;

    public AudioSource audioSource;
    public AudioClip preparing;
    public AudioClip exploision;

    private void Awake()
    {
        PreparingSound();
        anim = GetComponent<Animator>();
        bombDamageController = GetComponent<BombDamageController>();
    }

    private void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= timeToExploison)
            Boom();
    }
    
    private void Boom()
    {
        anim.SetTrigger("Boom");
        bomb.enabled = true;
        bombDamageController.takeDamage(this.transform);
    }

    public void destroyBomb()
    {
        Destroy(this.gameObject);
    }

    public void PreparingSound()
    {
        audioSource.PlayOneShot(preparing);
    }

    public void ExploisionSound()
    {
        audioSource.PlayOneShot(exploision);
    }
}
