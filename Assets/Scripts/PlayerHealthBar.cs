using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public int heartCount;
    public int maxHeartCount;
    public List<GameObject> hearts = new List<GameObject>();
    
    public void SetMaxHealth(int health)
    {
        maxHeartCount = (int)(health / 30);
        heartCount = maxHeartCount;
    }

    public void SetHealth(int health)
    {
        for (int i = 0; i < maxHeartCount; i++)
            hearts[i].SetActive(false);
        
        heartCount = (int)(health / 30);
        
        for (int i = 0; i < heartCount; i++)
            hearts[i].SetActive(true);
    }
}
