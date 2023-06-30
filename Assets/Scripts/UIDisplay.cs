using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Slider healthBar;

    Health health;
    ScoreKeeper scoreKeeper;
    int maxHealth;

    void Awake()
    {
        health = FindObjectOfType<Health>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthBar.maxValue = health.GetHealth();
        ChangeScore();
    }

    void Update()
    {
        healthBar.value = health.GetHealth();
        ChangeScore();
    }


    void ChangeScore()
    {
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("000000000");
    }
}
