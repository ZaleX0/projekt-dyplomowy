using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollectible : Collectible
{
    [SerializeField] TurretData turretData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UpdatePlayerTurret(collision);
    }

    private void UpdatePlayerTurret(Collider2D collision)
    {
        if (collision.tag == "Player") {
            var turret = collision.GetComponentInChildren<Turret>();
            turret.UpdateTurretData(turretData);
            Destroy(gameObject);
        }
    }
}
