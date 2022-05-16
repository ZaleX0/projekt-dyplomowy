using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTankMovementData", menuName = "Data/TankMovementData")]
public class TankMovementData : ScriptableObject
{
    public float maxSpeed = 1000;
    public float rotationSpeed = 300;
    public float acceleration = 1000;
    public float deacceleration = 1000;
}
