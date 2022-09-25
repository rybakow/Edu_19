using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeController : MonoBehaviour
{
    public Animator anim;
    private AnyDamageController anyDamageController;
    
    public GameObject observableObject;
    
    private void Awake()
    {
        anyDamageController = GetComponent<AnyDamageController>();
    }
    
    private void FixedUpdate()
    {
        transform.position = observableObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            Attack();
    }

    private void Attack()
    {
        anim.SetBool("isAttacking", true);
        anyDamageController.takeDamage(this.transform);
    }
    
}
