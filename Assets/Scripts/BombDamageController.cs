using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamageController : MonoBehaviour
{
    public float raduisOfDamage;
    public int damage;
    public LayerMask mask;

    private List<GameObject> damagedObjects = new List<GameObject>();
    
    public void takeDamage(Transform epicenter)
    {
        Collider2D[] listOfDamageable = getCollidersInCircle(epicenter);
        
        for (int i = 0; i < listOfDamageable.Length; i++)
        {
            GameObject damagedObject = listOfDamageable[i].gameObject;
            
            if (!damagedObjects.Contains(damagedObject))
            {
                if (damagedObject.CompareTag("Player"))
                    damagedObject.GetComponent<PlayerHealth>().CauseDamage(damage);
                else if (damagedObject.CompareTag("EnemyCharacter"))
                    damagedObject.GetComponent<AnyHealth>().CauseDamage(damage);
                
                damagedObjects.Add(damagedObject);
            }
        }
    }
    
    private Collider2D[] getCollidersInCircle(Transform epicenter)
    {
        Collider2D[] arrayOfDamagedObjects = Physics2D.OverlapCircleAll(epicenter.position, raduisOfDamage, mask);
        
        return arrayOfDamagedObjects;
    }


}
