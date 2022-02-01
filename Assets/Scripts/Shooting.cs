using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField] float bulletSpeed;
    [SerializeField] Camera mainCamera;
    public bool isFiring;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFiring)
        {
            Invoke("MakeProjectile", 0.2f);
            isFiring = true;
        }
    }
    private void MakeProjectile()
    {
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("projectile");
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.SetActive(true);
        }
    }
}