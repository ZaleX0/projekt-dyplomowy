using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector2 movementVector;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float rotationSpeed = 100;
    [SerializeField] float turretRotationSpeed = 100;

    public Transform turretHolder;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void HandleShoot()
    {
        Debug.Log("Shooting");
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        var turretDirection = (Vector3)pointerPosition - transform.position;
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
        var rotationStep = turretRotationSpeed * Time.deltaTime;

        turretHolder.rotation = Quaternion.RotateTowards(turretHolder.rotation, Quaternion.Euler(0, 0, desiredAngle - 90), rotationStep);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = maxSpeed * movementVector.y * Time.fixedDeltaTime * (Vector2)transform.up;
        rigidbody.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
