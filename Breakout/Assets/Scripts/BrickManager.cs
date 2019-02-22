using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public int rows;
    public int columns;
    public float spacingX;
    public float spacingY;
    public GameObject simpleBrickPrefab;

    public List<GameObject> bricks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ResetLevel();
    }

    public void ResetLevel()
    {
        //foreach(GameObject brick in bricks)
        //{
        //    Destroy(brick);
        //}
        //bricks.Clear();
        //
        //for (int x = 0; x < columns; x++)
        //{
        //    for (int y = 0; y < rows; y++)
        //    {
        //        Vector2 spawnPos = (Vector2)transform.position + new Vector2(
        //           x * (simpleBrickPrefab.transform.localScale.x + spacingX),
        //           -y * (simpleBrickPrefab.transform.localScale.y + spacingY)
        //           );
        //        GameObject brick = Instantiate(simpleBrickPrefab, spawnPos, Quaternion.identity);
        //        bricks.Add(brick);
        //    }
        //}
    }

    public GameObject GetClosestBrick(Transform origin)
    {
        GameObject[] currentBricks = GameObject.FindGameObjectsWithTag("Brick");
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        foreach (GameObject potentialTarget in currentBricks)
        {
            Vector3 distanceToTarget = potentialTarget.transform.position - origin.position;
            float dSqrToTarget = distanceToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}
