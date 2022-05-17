using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTurretData", menuName = "Data/TurretData")]
public class TurretData : ScriptableObject
{
    public Sprite sprite;
    public float spriteOffset;

    public GameObject bulletPrefab;
    public float reloadDelay = 1;
    public BulletData bulletData;
}
