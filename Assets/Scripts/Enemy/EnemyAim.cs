using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAim : MonoBehaviour
{
    public Transform objectToAimAt;
    public Transform childrenTank;

    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();

    private void Update()
    {
        GetTurretMovement();
    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(objectToAimAt.transform.position);
    }
}
