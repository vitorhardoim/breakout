using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Expand());
    }

    public IEnumerator Expand()
    {
        while (GetComponent<CircleCollider2D>().radius <= 0.8f)
        {
            GetComponent<CircleCollider2D>().radius += 0.001f;
            yield return null;
        }
    }
}
