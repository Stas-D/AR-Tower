using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float damage;
    [SerializeField] GameObject effects;
    Vector3 location;
    private void OnEnable()
    {
        location = gameObject.transform.position;
    }
    public void AreaDamageEnemies()
    {
        Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
        foreach (Collider col in objectsInRange)
        {
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null)
            {
                float proximity = (location - enemy.transform.position).magnitude;
                float effect = 1 - (proximity / radius);
                enemy.ApplyDamage(damage * effect);
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "projectile")
        {
            AreaDamageEnemies();
            Instantiate(effects, transform.position, Quaternion.identity);
        }
    }
}