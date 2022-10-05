using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
   
    public bool isItNextLevel;
    public bool didExit;
    
    private Animator anim;

    public AudioSource audioSource;
    public AudioClip openDoorSound;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && ((isItNextLevel) || (!isItNextLevel && didExit)))
        {
            audioSource.PlayOneShot(openDoorSound);
            anim.SetTrigger("DoorOpen");
        }
    }

    public void LevelController()
    {
        if (isItNextLevel)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            if (didExit)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            didExit = true;
    }
}
