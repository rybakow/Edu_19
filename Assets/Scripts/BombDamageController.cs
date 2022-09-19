using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamageController : MonoBehaviour
{
    public float raduisOfDamage;
    public int damage;
    public LayerMask mask;

    private GameObject lastBomb;


    public void takeDamage(Transform epicenter)
    {
        List<DamageableList> listOfDamageable = getCollidersInCircle(epicenter);

        for (int i = 0; i < listOfDamageable.Count; i++)
        {
            Debug.Log("damageableObject = " + listOfDamageable[i].damageableObject.name + " " + "bombObject = " + listOfDamageable[i].bombObject.name + " lastBomb = " + lastBomb.name);
            if (listOfDamageable[i].bombObject != lastBomb)
            {
                listOfDamageable[i].damageableObject.GetComponent<Health>().CauseDamage(damage);
                //listOfDamageable[i].bombObject = epicenter.gameObject;
            }
        }
    }
    
    
    private List<DamageableList> getCollidersInCircle(Transform epicenter)
    {
        lastBomb = epicenter.gameObject;
        Collider2D[] arrayOfDamagedObjects = Physics2D.OverlapCircleAll(epicenter.position, raduisOfDamage, mask);
        List<DamageableList> result = new List<DamageableList>();

        for (int i = 0; i < arrayOfDamagedObjects.Length; i++)
            result.Add(new DamageableList(arrayOfDamagedObjects[i].gameObject, epicenter.gameObject));
        
        return result;
    }
    

}
