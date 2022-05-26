using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollectible : Collectible
{
    [SerializeField] TurretData turretData;
    [SerializeField] private AudioSource weaponSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UpdatePlayerTurret(collision);
        
    }

    private void UpdatePlayerTurret(Collider2D collision)
    {
        if (collision.tag == "Player") {
            var turret = collision.GetComponentInChildren<Turret>();
            turret.UpdateTurretData(turretData);
            weaponSound.Play();
            DisableComponents();
            Destroy(gameObject, 1f);
        }
    }

    void DisableComponents()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
