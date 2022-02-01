using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] float maxTowerHealth = 100f;
    float towerHealth;
    [SerializeField] private Slider slider;
    [SerializeField] private StartRestart gameHandler;
    void Start()
    {
        towerHealth = maxTowerHealth;
        slider.maxValue = towerHealth;
        slider.value = towerHealth;
    }
    public void TakeDamage(int amount)
    {
        towerHealth = towerHealth - amount;
        slider.value = towerHealth;
        if (towerHealth <= 0)
        {
            gameHandler.EndGame();
        }
    }
    public void RestoreHealth()
    {
        towerHealth = maxTowerHealth;
        slider.value = towerHealth;
    }
}