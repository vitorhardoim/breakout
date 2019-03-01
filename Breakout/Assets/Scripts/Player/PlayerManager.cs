using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public int streak;
    public int score;
    int lastScore;
    public int lifes;
    public float qtdRight;
    public float qtdLeft;

    public GameObject Canvas;
    public Text[] scoreTexts;
    public Text lifeText;
    public Text streakText;

    public Inventory inventory;

    void Awake() { instance = this; }

    void Start()
    {
        score = 0;
        lifes = 3;
        qtdRight = 0;
        qtdLeft = 0;
        inventory = new Inventory();
        inventory.FillPositions();
    }

    void Update()
    {
        if(score != lastScore)
        {
            UpdateScore();
            lastScore = score;
        }
        UpdateStreak();
        lifeText.text = "x" + lifes;
    }

    private void UpdateStreak()
    {
        if(streak <= 1)
        {
            streakText.text = "1x";
            streakText.color = Color.white;
        }
        if(streak == 2)
        {
            streakText.text = "2x";
            streakText.color = Color.yellow;
        }
        if (streak == 3)
        {
            streakText.text = "3x";
            streakText.color = new Color(1f, 0.5f, 0f);
        }
        if ((streak >= 4) && (streak < 8))
        {
            streakText.text = streak + "x";
            streakText.color = Color.red;
        }
        if(streak >= 8)
        {
            streak = 8;
            streakText.text = streak + "x";
            streakText.color = new Color(0.6f, 0, 1);
        }
    }

    public void UpdateScore()
    {
        for (int i = 9; i >= 1; i--)
        {
            scoreTexts[i-1].text = (Mathf.Floor(score / (Mathf.Pow(10, -(i-9))) % 10)).ToString();
        }
    }

        
}
