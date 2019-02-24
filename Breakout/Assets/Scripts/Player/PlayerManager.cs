using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int streak;
    public int score;
    int lastScore;
    public int lifes;
    public float qtdRight;
    public float qtdLeft;
    public int qtdBuffs;
    GameObject[] activeBuffs = new GameObject[9];

    public GameObject Canvas;
    public Text[] scoreTexts;
    public Text lifeText;
    public Text streakText;

    List<Vector2> buffsPositions = new List<Vector2>();
    public bool[] usedSlots = new bool[9];

    void Start()
    {
        score = 0;
        lifes = 3;
        qtdRight = 0;
        qtdLeft = 0;
        FillPositions();
        Debug.Log(usedSlots[0]);
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

    public void SetBuffInList(GameObject buff)
    {
        buff.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        if (BuffAlreadyInList(buff))
        {
            Destroy(buff);
        }
        else
        {
            activeBuffs[qtdBuffs] = buff;
            buff.transform.position = buffsPositions[qtdBuffs];
            usedSlots[qtdBuffs] = true;
            qtdBuffs++;
        }
        
    }

    public void RedefinePosition(GameObject buff)
    {
        int position = System.Array.IndexOf(activeBuffs, buff);
        for(int i = 0; i < position; i++)
        {
            if(usedSlots[i] == false)
            {
                buff.transform.position = buffsPositions[i];
                usedSlots[i] = true;
                usedSlots[position] = false;
                return;
            }
        }
    }

    public bool BuffAlreadyInList(GameObject buff)
    {
        foreach(GameObject buffObject in activeBuffs)
        {
            if(buffObject != null)
            {
                if (buffObject.tag == buff.tag)
                {
                    if (buff.tag == "SpeedUp")
                    {
                        buffObject.GetComponent<SpeedUp>().RefillTime();
                    }
                    if (buff.name == "TazerUp")
                    {
                        buffObject.GetComponent<TazerpUP>().RefillTime();
                    }
                    return true;
                }
            }
        }
        return false;
    }

    public void RemoveBuffFromList(GameObject buff)
    {
        foreach (GameObject buffObject in activeBuffs)
        {
            if (buffObject != null)
            {
                if (buffObject.tag == buff.tag)
                {
                    int temp = System.Array.IndexOf(activeBuffs, buffObject);
                    activeBuffs[temp] = null;
                    usedSlots[temp] = false;
                }
            }
        }
    }

    void FillPositions()
    {
        for (int i = 0; i <= 9; i++)
        {
            buffsPositions.Add(new Vector2(8.33f, 4.22f - (0.7f*i)));
        }
    }
}
