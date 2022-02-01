using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRestart : MonoBehaviour
{
    [SerializeField] private Spawner[] AllSpawners;
    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject restartWindow;
    private Tower towerHealth;
    [SerializeField] private GameObject towerModel;
    void Start()
    {
        towerHealth = tower.GetComponent<Tower>();
    }
    public void EndGame()
    {
        ObjectPooler.SharedInstance.DisableAllEnemies();
        towerModel.SetActive(false);
        restartWindow.SetActive(true);
        DisableSpawn();
    }
    public void Restart()
    {
        towerModel.SetActive(true);
        towerHealth.RestoreHealth();
        Score.instance.ResetScore();
        EnableSpawn();
        restartWindow.SetActive(false);
    }
    private void DisableSpawn()
    {
        foreach (Spawner spawner in AllSpawners)
        {
            spawner.stopSpawn = true;
        }
    }
        private void EnableSpawn()
    {
        foreach (Spawner spawner in AllSpawners)
        {
            spawner.stopSpawn = false;
        }
    }
}