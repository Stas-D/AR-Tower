using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private void OnEnable()
    {
        scoreText.text = Score.instance.score.ToString();
    }
}