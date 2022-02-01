using UnityEngine;
using System.Collections;

public class ThrowSimulation : MonoBehaviour
{
    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
    public Transform Projectile;
    private Transform tower;
    public ProjectileLandPlace landPlace;
    private Shooting bullet;
    private void OnEnable()
    {
        tower = GameObject.FindWithTag("tower").GetComponent<Transform>();
        Target = GameObject.FindWithTag("target").GetComponent<Transform>();
        Projectile = transform;
        landPlace = tower.gameObject.GetComponent<ProjectileLandPlace>();
        bullet = tower.gameObject.GetComponent<Shooting>();
        StartCoroutine(SimulateProjectile());
    }
    IEnumerator SimulateProjectile()
    {
        yield return new WaitForSeconds(0.2f);
        Projectile.position = tower.position + new Vector3(0, 0.0f, 0);
        // Calculate distance to target and velocity
        float target_Distance = Vector3.Distance(Projectile.position, Target.position);
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
        // Calculate flight time.
        float flightDuration = target_Distance / Vx;
        Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);
        float elapse_time = 0;
        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
            elapse_time += Time.deltaTime;
            yield return null;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "target")
        {
            StopCoroutine(SimulateProjectile());
            landPlace.isFiring = false;
            bullet.isFiring = false;
            col.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}