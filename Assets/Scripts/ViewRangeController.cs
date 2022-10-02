using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewRangeController : MonoBehaviour
{
   public GameObject observableObject;
   private EnemyCharacterController characterController;

   private void Awake()
   {
      characterController = observableObject.GetComponent<EnemyCharacterController>();
   }

   private void FixedUpdate()
   {
      if (observableObject)
         transform.position = observableObject.transform.position;
   }

   private void OnTriggerEnter2D(Collider2D collider)
   {
      if (collider.gameObject.CompareTag("Player"))
         characterController.target = collider.gameObject.transform;
   }

   private void OnTriggerExit2D(Collider2D collider)
   {
      if (collider.gameObject.CompareTag("Player"))
         characterController.target = null;
   }
}
