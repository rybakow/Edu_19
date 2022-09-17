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

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= timeToExploison)
            Boom();
    }


    private void Boom()
    {
        anim.SetTrigger("Boom");
        bomb.enabled = true;
    }

    public void destroyBomb()
    {
        Destroy(this.gameObject);
    }
}
