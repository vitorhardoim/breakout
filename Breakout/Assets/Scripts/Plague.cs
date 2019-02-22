using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plague : MonoBehaviour
{
    GameObject host;
    float timeLeft;
    bool active;
    bool exploding;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        exploding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0)
            {
                StartCoroutine(Expand());
                if (exploding)
                {
                    Destroy(host);
                    Destroy(gameObject);
                }
            }
            if (host == null)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.gameObject.tag == "Brick") && (active == false))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            host = other.gameObject;
            gameObject.transform.position = other.gameObject.transform.GetComponent<Renderer>().bounds.center;
            timeLeft = 5;
            active = true;
        }
        if (other.gameObject.tag == "Limit")
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((exploding == true) && (other.gameObject.tag == "Brick"))
        {
            Destroy(other.gameObject);
        }
    }

    public IEnumerator Expand()
    {
        float elapsed = 0.0f;

        while (elapsed < 1f)
        {
            GetComponent<Rigidbody2D>().transform.localScale += new Vector3(0.005f, 0.005f, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }
        exploding = true;
    }
}
