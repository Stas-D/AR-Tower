using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTower : MonoBehaviour
{
    Transform myTransform;
    [SerializeField] Transform target;
    void Awake()
    {
        myTransform = transform;       
    }
    void LateUpdate()
    {
        myTransform.LookAt(target);
    }
}
