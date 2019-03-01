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

    void Start() {
        score = 0;
        lifes = 3;
        qtdRight = 0;
        qtdLeft = 0;
        inventory = new Inventory();
        inventory.FillPositions();
    }

    void Update() {
        if(score != lastScore) {
            UpdateScore();
            lastScore = score;
        }
        UpdateStreak();
        lifeText.text = "x" + lifes;
    }

    private void UpdateStreak() { 
        streakText.text = streak + "x";
        switch (streak) {
            case 1:
                streakText.color = Color.white;
                break;
            case 2:
                streakText.color = Color.yellow;
                break;
            case 3:
                streakText.color = new Color(1f, 0.5f, 0f);
                break;
            case 8:
                streakText.color = new Color(0.6f, 0, 1);
                break;
            default:
                streakText.color = Color.red;
                break;
        }
    }

    public void UpdateScore() {
        for (int i = 9; i >= 1; i--) {
            scoreTexts[i-1].text = (Mathf.Floor(score / (Mathf.Pow(10, -(i-9))) % 10)).ToString();
        }
    }
}