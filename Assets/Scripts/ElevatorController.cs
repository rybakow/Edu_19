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

    public void MovePlatform(bool up)
    {
        if (up)
            target = topPoint.transform;
        else
            target = bottomPoint.transform;
    }

    private void Update()
    {
        if (target)
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, target.position, Time.deltaTime);
        
        if (platform.transform.position.y == target.transform.position.y)
            MovePlatform(false);
    }
}
