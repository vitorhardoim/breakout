using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerativeBrick : BaseBrick
{
    public GameObject summonedBrick;
    public GameObject[] extraBricks = new GameObject[4];
    float[] cooldowns;
    Vector2[] gaps;
    Vector2[] velocities;
   

    new void Start()
    {
        base.Start();
        cooldowns = new float[4];
        cooldowns[0] = cooldowns[1] = cooldowns[2] = cooldowns[3] = 10f;

        gaps = new Vector2[4];
        gaps[0] = new Vector2(0, 0.5f);
        gaps[1] = new Vector2(0.8f, 0);
        gaps[2] = new Vector2(0, -0.5f);
        gaps[3] = new Vector2(-0.8f, 0);

        extraBricks[0] = Instantiate(summonedBrick, new Vector2(rb.position.x, rb.position.y) + new Vector2(0, 0.5f), Quaternion.identity);
        extraBricks[1] = Instantiate(summonedBrick, new Vector2(rb.position.x, rb.position.y) + new Vector2(0.8f, 0), Quaternion.identity);
        extraBricks[2] = Instantiate(summonedBrick, new Vector2(rb.position.x, rb.position.y) + new Vector2(0, -0.5f), Quaternion.identity);
        extraBricks[3] = Instantiate(summonedBrick, new Vector2(rb.position.x, rb.position.y) + new Vector2(-0.8f, 0), Quaternion.identity);
    }

    private void Update()
    {
        for(int i = 0; i<4; i++)
        {
            if (extraBricks[i] == null)
            {
                cooldowns[i] -= Time.deltaTime;
                if (cooldowns[i] <= 0)
                {
                    cooldowns[i] = 10;
                    extraBricks[i] = Instantiate(summonedBrick, rb.position + gaps[i], Quaternion.identity);
                    extraBricks[i].GetComponent<SimpleBrick>().initialLife = 1;
                }
            }
        }
    }

}
