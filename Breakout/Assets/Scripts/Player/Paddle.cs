using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	public float speed = 5f;
	private float input;
    private bool onCorner;

    public GameObject plaguePrefab;
    public GameObject paddleTilePrefab;
    public GameObject shieldPrefab;
    public CameraShake cameraShake;
    public GameObject tazerPrefab;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		input = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("q"))
        {
            SpawnNewBlocks();
        }
        if (Input.GetKeyDown("w"))
        {
            Earthquake();
        }
        if (Input.GetKeyDown("e"))
        {
            BottomShield();
        }
        if (Input.GetKeyDown("r"))
        {
            SpreadPlague();
        }
        if (Input.GetKeyDown("t"))
        {
            Tazer();
        }
        if (Input.GetKeyDown("y"))
        {
            GameObject.FindWithTag("Ball").GetComponent<Ball>().constantSpeed /= 3;
        }
        if (Input.GetKeyUp("y"))
        {
            GameObject.Find("Ball").GetComponent<Ball>().constantSpeed = GameObject.Find("Ball").GetComponent<Ball>().originalSpeed;
        }

    }

    private void FixedUpdate(){
		GetComponent<Rigidbody2D>().velocity = Vector2.right * input * speed;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SideWall")
        {
            onCorner = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SideWall")
        {
            onCorner = false;
        }
    }
    public bool IsOnCorner()
    {
        return onCorner;
    }

    void SpreadPlague()
    {
        float plagueDirec = -1f;
        for (int i = 0; i<9; i++)
        {
            plagueDirec += 0.2f;
            GameObject plagueShot = Instantiate(plaguePrefab, GetComponent<Renderer>().bounds.center, Quaternion.identity);
            plagueShot.GetComponent<Rigidbody2D>().velocity = new Vector2(plagueDirec, 1).normalized * 5;
        }
    }
    
    private void SpawnNewBlocks()
    {
        Instantiate(paddleTilePrefab, new Vector2(8.5f, rb.transform.position.y), Quaternion.identity);
        Instantiate(paddleTilePrefab, new Vector2(-8.5f, rb.transform.position.y), Quaternion.identity);
    }

    void Earthquake()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));
    }

    void BottomShield()
    {
        Instantiate(shieldPrefab, new Vector2(0, -5), Quaternion.identity);
    }

    void Tazer()
    {
        StartCoroutine(tazerPrefab.GetComponent<Tazer>().DispenseTazer(gameObject));
    }
}
