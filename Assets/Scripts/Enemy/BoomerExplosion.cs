using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerExplosion : MonoBehaviour
{
    [SerializeField] GameObject ExplosionEffect;

    [SerializeField] int damagePoints;
    [SerializeField] float explosionRadius;

    public void Explode()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (var collision in collisions)
        {
            if (collision.tag == "Player")
            {
                DealDamage(collision, damagePoints);
            }

            if (collision.tag == "Enemy")
            {
                DealDamage(collision, damagePoints);
            }
        }

        GameObject explosionEffectInstance = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        explosionEffectInstance.transform.localScale = Vector3.one * 4;
        Destroy(explosionEffectInstance, 0.5f);
    }

    private void DealDamage(Collider2D collision, int damagePoints)
    {
        var damagable = collision.GetComponent<Damagable>();
        if (damagable != null)
            damagable.Hit(damagePoints);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var damagable = GetComponentInParent<Damagable>();
            if (damagable != null)
                damagable.Hit(damagable.Health);
        }
    }
}
