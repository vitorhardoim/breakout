using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBrick : MonoBehaviour
{
    public int chance;
    public float initialLife;
    float life;

    public GameObject speedUpPrefab;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        life = initialLife;
        if (life <= 1)
        {
            life = 1;
        }
        if (life > 6)
        {
            life = 6;
        }
    }

    void Update()
    {
        if(life == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        if (life == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (life == 3)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (life == 4)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        }
        if (life == 5)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (life == 6)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }

    private void LateUpdate()
    {
        if (life <= 0)
        {
            GameObject.Find("Player").GetComponent<Player>().score += GameObject.Find("Player").GetComponent<Player>().streak * (int)initialLife * 10;
            Drop(speedUpPrefab);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            life -= other.gameObject.GetComponent<Ball>().damage;
        }
    }

    private void Drop(GameObject powerUp)
    {
        int randomValue = Random.Range(0, 100);
        if(randomValue<= chance)
        {
            Instantiate(speedUpPrefab, rb.position, Quaternion.identity);
        }
    }
}
