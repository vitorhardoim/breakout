using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBrick : BaseBrick
{
    Collider2D[] otherBricks = new Collider2D[20];

    private new void OnDestroy()
    {
        base.OnDestroy();
        Physics2D.OverlapCircle(gameObject.GetComponent<Renderer>().bounds.center, 0.9f, default, otherBricks);
        foreach (Collider2D col in otherBricks)
        {
            if ((col != null) && (col.gameObject.tag == "Brick"))
            {
                Destroy(col.gameObject);
            }
        }
    }
}
