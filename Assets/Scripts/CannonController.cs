using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonBall;
    public GameObject shotPoint;

    public GameObject whale;
    private Animator anim;

    private void Awake()
    {
        anim = whale.GetComponent<Animator>();
    }
    
    public void Shot()
    {
        GameObject newCannonBall = Instantiate(cannonBall, cannonBall.transform.position, Quaternion.identity);
        newCannonBall.SetActive(true);
        newCannonBall.GetComponent<Rigidbody2D>().velocity = shotPoint.transform.position * 1.35f;
    }

    public void WhaleAttack(bool active)
    {
        if (active)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);
    }
}
