using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : MonoBehaviour
{
    Transform myTransform;
    Transform target;
    void Awake()
    {
        myTransform = transform; 
        target = Camera.main.transform; 
    }
    void LateUpdate()
    {
        myTransform.LookAt(target);
    }
}
