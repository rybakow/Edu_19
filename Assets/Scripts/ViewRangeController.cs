using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewRangeController : MonoBehaviour
{
   public GameObject observableObject;
   private PirateController characterController;

   private void Awake()
   {
      characterController = observableObject.GetComponent<PirateController>();
   }

   private void FixedUpdate()
   {
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
