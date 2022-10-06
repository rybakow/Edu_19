using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonController : MonoBehaviour
{
    private bool buttonPressed;
    private float currentTime;

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
        Debug.Log(collider.name);
        if (collider.CompareTag("Player") || collider.CompareTag("ActiveInventory"))
        {
            buttonPressed = true;
            anim.SetBool("buttonPressed", true);
            audioSource.PlayOneShot(buttonPressedSound);
            elevatorController.MovePlatform(true);
        }
    }

    private void Update()
    {
        if (buttonPressed)
        {
            currentTime += Time.deltaTime;
            
            if (currentTime > 3f)
            {
                buttonPressed = false;
                currentTime = 0;
                anim.SetBool("buttonPressed", false);
                audioSource.PlayOneShot(buttonPressedSound);
            }
        }
    }
}
