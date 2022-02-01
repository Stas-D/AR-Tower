using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth;
    [SerializeField] int damage;
    float turnSpeed = 4f;
    private GameObject tower;
    private Tower towerHealth;
    [SerializeField] private Slider slider;
    private void OnEnable()
    {
        tower = GameObject.FindWithTag("tower");
        towerHealth = tower.GetComponent<Tower>();
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    void Update()
    {
        if (tower != null)
        {
            Vector3 direction = tower.transform.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction), turnSpeed * Time.smoothDeltaTime);
        }
        this.transform.Translate(0, 0, speed);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "tower")
        {
            towerHealth.TakeDamage(damage);
            this.gameObject.SetActive(false);
        }
    }
    public void ApplyDamage(float amount)
    {
        currentHealth = currentHealth - amount;
        slider.value = currentHealth;
        if (currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
            Score.instance.IncreaseScore(maxHealth);
        }
    }
}