using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public GameObject platform;
    
    public GameObject topPoint;
    public GameObject bottomPoint;
    
    private Transform target;

    public bool movingPlatform;
    
    public void MovePlatform()
    {
        if (movingPlatform)
            if (target)
            {
                platform.transform.position = Vector2.MoveTowards(platform.transform.position, target.position, Time.deltaTime);
                
                if (platform.transform.position.y == topPoint.transform.position.y)
                    target = bottomPoint.transform;
                else if (platform.transform.position.y == bottomPoint.transform.position.y)
                    target = topPoint.transform;
            }
            else
                target = topPoint.transform;
        else
        {
            platform.transform.position =
                Vector2.MoveTowards(platform.transform.position, bottomPoint.transform.position, Time.deltaTime);
        }
    }

    private void Update()
    {
        MovePlatform();
    }
}
