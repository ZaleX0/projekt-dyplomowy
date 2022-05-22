using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : Collectible
{
    [SerializeField] int healAmount = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealPlayer(collision);
    }

    private void HealPlayer(Collider2D collision)
    {
        if (collision.tag == "Player") {
            var damagable = collision.GetComponent<Damagable>();
            if (damagable != null) {
                damagable.Heal(healAmount);
            }
            Destroy(gameObject);
        }
    }
}
