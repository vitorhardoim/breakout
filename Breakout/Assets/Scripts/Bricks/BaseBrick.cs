﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBrick : MonoBehaviour
{
    public int chance;
    public float initialLife;
    public float life;

    public GameObject[] powerUpList = new GameObject[2];
    public Rigidbody2D rb;

    public void Start()
    {
        life = initialLife;
        rb = GetComponent<Rigidbody2D>();
    }

    public void LateUpdate()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDestroy() {
       if (PlayerManager.instance.streak != 0) 
           PlayerManager.instance.score += PlayerManager.instance.streak * (int)initialLife * 10;
       else PlayerManager.instance.score += 1 * (int)initialLife * 10;
    
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            life -= other.gameObject.GetComponent<Ball>().damage;
        }
    }

    public void Drop(GameObject powerUp)
    {
        int randomValue = Random.Range(0, 100);
        if (randomValue <= chance)
        {
            Instantiate(powerUp, rb.position, Quaternion.identity);
        }
    }
}