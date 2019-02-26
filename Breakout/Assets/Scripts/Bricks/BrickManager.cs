using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
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
