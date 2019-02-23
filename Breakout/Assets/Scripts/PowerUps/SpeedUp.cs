using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    float timeLeft;
    bool active;
    private Rigidbody2D rb;
    float blinkCooldown;
    GameObject[] balls;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        active = false;
    }

    void Update()
    {
        if (active == true)
        {
            GameObject.Find("Player").GetComponent<Player>().RedefinePosition(gameObject);
            balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in balls)
            {
                ball.GetComponent<Ball>().constantSpeed = GameObject.Find("Ball").GetComponent<Ball>().originalSpeed + 5;
            }
            blinkCooldown -= Time.deltaTime;
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                foreach(GameObject ball in balls)
                {
                    ball.GetComponent<Ball>().constantSpeed = GameObject.Find("Ball").GetComponent<Ball>().originalSpeed;
                }
                GameObject.Find("Player").GetComponent<Player>().qtdBuffs--;
                GameObject.Find("Player").GetComponent<Player>().RemoveBuffFromList(gameObject);
                Destroy(gameObject);
            }
            if ((timeLeft <= 1) && (blinkCooldown <= 0))
            {
                blinkCooldown = 0.1f;
                StartBlinking();
            }
        }
    }

    private void StartBlinking()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Paddle")
        {
            timeLeft = 3f;
            active = true;
            GameObject.Find("Player").GetComponent<Player>().SetBuffInList(gameObject);
        }
    }

    public void RefillTime()
    {
        timeLeft = 3f;
    }
}
