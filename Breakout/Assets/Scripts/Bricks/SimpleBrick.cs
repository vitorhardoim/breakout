using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBrick : BaseBrick
{

    new void Start()
    {
        base.Start();
        if (life <= 1) life = 1;
        if (life > 6) life = 6;
    }

    void Update()
    {
        if (life == 1) gameObject.GetComponent<Renderer>().material.color = Color.white;
        if (life == 2) gameObject.GetComponent<Renderer>().material.color = Color.green;
        if (life == 3) gameObject.GetComponent<Renderer>().material.color = Color.blue;
        if (life == 4) gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        if (life == 5) gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        if (life == 6) gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    new void LateUpdate()
    {
        base.LateUpdate();
        if (life <= 0)
        {
            System.Random r = new System.Random();
            Drop(powerUpList[r.Next(0, powerUpList.Length)]);
        }
    }
}
