using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleTile : MonoBehaviour
{
    private Rigidbody2D rb;
    bool moving;
    GameObject paddleMaster;
    string type;
    float qtdRight;
    float qtdLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paddleMaster = GameObject.Find("Paddle");
        moving = true;
        if (rb.transform.position.x > 0)
        {
            type = "right";
            qtdRight = GameObject.Find("Player").GetComponent<Player>().qtdRight;
            GameObject.Find("Player").GetComponent<Player>().qtdRight++;
        }
        if (rb.transform.position.x < 0)
        {
            type = "left";
            qtdLeft = GameObject.Find("Player").GetComponent<Player>().qtdLeft;
            GameObject.Find("Player").GetComponent<Player>().qtdLeft++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if(type == "right")
            {
                rb.velocity = new Vector2(-10, 0);
            }
            if (type == "left")
            {
                rb.velocity = new Vector2(10, 0);
            }
        }
        else
        {
            if (type == "right")
            {
                rb.velocity = new Vector2(0, 0);
                transform.position = Vector3.MoveTowards(transform.position, paddleMaster.transform.position + new Vector3((paddleMaster.GetComponent<SpriteRenderer>().bounds.size.x + 0.015f) * (qtdRight+1), 0, 0), 1);

            }
            if (type == "left")
            {
                rb.velocity = new Vector2(0, 0);
                transform.position = Vector3.MoveTowards(transform.position, paddleMaster.transform.position + new Vector3((-paddleMaster.GetComponent<SpriteRenderer>().bounds.size.x - 0.015f) * (qtdLeft+1), 0, 0), 1);

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Paddle")
        {
            moving = false;
            rb.velocity = new Vector2(0, 0);
            GetComponent<Collider2D>().isTrigger = true;
            paddleMaster.GetComponent<BoxCollider2D>().size += new Vector2(paddleMaster.GetComponent<SpriteRenderer>().bounds.size.x + 0.015f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
        }
    }
}
