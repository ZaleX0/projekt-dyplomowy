using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{

    private Vector2 movementVector;
    private Rigidbody2D rigidbody;
    private AudioSource audioSource;

    public TankMovementData movementData;

    private float currentSpeed = 0;
    private float currentForewardDirection = 1;


    private void Awake()
    {
        rigidbody = GetComponentInParent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (audioSource != null)
            audioSource.Play();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        if (movementVector.y > 0)
            currentForewardDirection = 1;
        else if (movementVector.y < 0)
            currentForewardDirection = -1;
    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
            currentSpeed += movementData.acceleration * Time.deltaTime;
        else
            currentSpeed -= movementData.deacceleration * Time.deltaTime;

        currentSpeed = Mathf.Clamp(currentSpeed, 0, movementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = currentSpeed * currentForewardDirection * Time.fixedDeltaTime * (Vector2)transform.up;
        rigidbody.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * movementData.rotationSpeed * Time.fixedDeltaTime));

        UpdateDrivePitch();
    }

    void UpdateDrivePitch()
    {
        if (audioSource != null)
            audioSource.pitch = 1 + Mathf.Clamp01(currentSpeed / 1000);
    }
}
