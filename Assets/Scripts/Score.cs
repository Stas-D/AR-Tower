using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance = null;
    public float score = 0;
    [SerializeField] private Text scoreText;
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        instance = this;
    }
    private void Start()
    {
        scoreText.text = score.ToString();
    }
    public void IncreaseScore(float amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
}