using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonController : MonoBehaviour
{
    private Animator anim;

    public AudioSource audioSource;
    public AudioClip buttonPressedSound;

    public ElevatorController elevatorController;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("ActiveInventory"))
            audioSource.PlayOneShot(buttonPressedSound);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("ActiveInventory"))
        {
            elevatorController.movingPlatform = true;
            anim.SetBool("buttonPressed", true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("ActiveInventory"))
        {
            elevatorController.movingPlatform = false;
            anim.SetBool("buttonPressed", false);
            audioSource.PlayOneShot(buttonPressedSound);
        }
    }

}
