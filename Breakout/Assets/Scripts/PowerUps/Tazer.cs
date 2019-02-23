using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tazer : MonoBehaviour
{
    private LineRenderer lr;
    GameObject laserHit;
    Vector3 posGrown;
    BrickManager brickManager;
    Transform paddle;
    float fadeTime;

    private void Start()
    {
        paddle = GameObject.FindWithTag("Paddle").transform;
        brickManager = GameObject.FindWithTag("BrickManager").GetComponent<BrickManager>();
        laserHit = brickManager.GetClosestBrick(paddle);
        lr = GetComponent<LineRenderer>();
        posGrown = transform.position;
        fadeTime = .09f;
    }
    private void Update()
    {
        if (laserHit == null)
        {
            Destroy(gameObject);
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, laserHit.transform.position);
        lr.SetPosition(0, paddle.transform.position);
        lr.SetPosition(1, laserHit.transform.position);
        fadeTime -= Time.deltaTime;
        if(fadeTime <= 0)
        {
            Destroy(laserHit);
            Destroy(gameObject);
        }
    }

    public IEnumerator DispenseTazer(GameObject paddle)
    {
        float reloadTime = 2f;
        int shots = 5;
        while (shots > 0)
        {
            reloadTime -= Time.deltaTime;
            if(reloadTime <= 0)
            {
                Instantiate(gameObject, paddle.transform.position, Quaternion.identity);
                shots--;
                reloadTime = 2f;
            }
            yield return null;
        }
    }
}
