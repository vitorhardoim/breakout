using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TazerpUP : MonoBehaviour
{
    float timeLeft;
    bool active;
    private Rigidbody2D rb;
    float blinkCooldown;
    public GameObject tazerPrefab;

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
            blinkCooldown -= Time.deltaTime;
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
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
            StartCoroutine(tazerPrefab.GetComponent<Tazer>().DispenseTazer(gameObject));
            timeLeft = 10f;
            active = true;
            GameObject.Find("Player").GetComponent<Player>().SetBuffInList(gameObject);
        }
    }

    public void RefillTime()
    {
        StopCoroutine(tazerPrefab.GetComponent<Tazer>().DispenseTazer(gameObject));
        timeLeft = 10f;
        StartCoroutine(tazerPrefab.GetComponent<Tazer>().DispenseTazer(gameObject));
    }
}
