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
        int actualSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (isItNextLevel)
        {
            if (actualSceneIndex + 1 > GameState.totalLevelsInGame)
                SceneManager.LoadScene("ResultScene");
            else 
                SceneManager.LoadScene(actualSceneIndex + 1);
        }
        else
            if (didExit)
                SceneManager.LoadScene(actualSceneIndex - 1);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            didExit = true;
    }
}
