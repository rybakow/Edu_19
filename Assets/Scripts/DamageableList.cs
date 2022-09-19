using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableList : MonoBehaviour
{
    public GameObject damageableObject;
    public GameObject bombObject;

    public DamageableList(GameObject dObject, GameObject bObject)
    {
        damageableObject = dObject;
        bombObject = bObject;
    }
}
