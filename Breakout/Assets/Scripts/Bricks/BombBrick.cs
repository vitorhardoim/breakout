using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBrick : BaseBrick
{
    bool explode;
    public GameObject explosion;

    private void Update()
    {
        if (explode)
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            if(explosion = null)
            {
                Destroy(gameObject);
            }
        }
    }

    new void LateUpdate()
    {
        if(life <= 0)
        {
            explode = true;
        }
    }
}
