using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    public Transform targetObject;
    public Transform childrenTank;

    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();
    public UnityEvent OnShoot = new UnityEvent();

    private void Update()
    {
        MoveTowardsObject();
        GetTurretMovement();
        Shoot();
    }

    private void MoveTowardsObject()
    {
        Vector2 directionToGo = targetObject.position - childrenTank.position;

        float dot = Vector2.Dot(childrenTank.right, directionToGo.normalized);
        float angle = Vector2.Angle(childrenTank.up, directionToGo) * Mathf.Deg2Rad;

        Vector2 result;

        if (dot > 0)
            result = new Vector2(angle, 1);
        else
            result = new Vector2(-angle, 1);
        
        OnMoveBody?.Invoke(result);
    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(targetObject.transform.position);
    }

    private void Shoot()
    {
        // TODO: shoot below some distance to the target object
        OnShoot?.Invoke();
    }
}
