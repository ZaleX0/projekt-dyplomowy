using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFollow : MonoBehaviour
{
    public Transform objectToFollow;
    public Transform childrenTank;

    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();




    private void Update()
    {
        MoveTowardsObject();
    }

    private void MoveTowardsObject()
    {
        Vector2 directionToGo = objectToFollow.position - childrenTank.position;

        float dot = Vector2.Dot(childrenTank.right, directionToGo.normalized);
        float angle = Vector2.Angle(childrenTank.up, directionToGo) * Mathf.Deg2Rad;

        Vector2 result;
        if (dot > 0)
        {
            result = new Vector2(angle, 1);
        }
        else
        {
            result = new Vector2(-angle, 1);
        }

        OnMoveBody?.Invoke(result);
    }
}
