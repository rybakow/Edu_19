using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleAttackController : MonoBehaviour
{
   public CannonController cannonController;
   
   private void OnTriggerEnter2D(Collider2D collider)
   {
      if (collider.CompareTag("Player"))
      {
         cannonController.Shot();
         cannonController.WhaleAttack(true);
      }
   }

   private void OnTriggerExit2D(Collider2D collider)
   {
      if (collider.CompareTag("Player"))
         cannonController.WhaleAttack(false);
   }
}
