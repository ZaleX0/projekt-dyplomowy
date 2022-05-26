using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerExplosion : MonoBehaviour
{
    [SerializeField] GameObject ExplosionEffect;

    [SerializeField] int damagePoints;
    [SerializeField] float explosionRadius;

    [SerializeField] Animator animator;

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


        ExplosionAnimation();
    }

    private void DealDamage(Collider2D collision, int damagePoints)
    {
        var damagable = collision.GetComponent<Damagable>();
        if (damagable != null)
            damagable.Hit(damagePoints);
    }

    void ExplosionAnimation()
    {
        animator?.SetTrigger("Death");

        GameObject explosionEffectInstance = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        explosionEffectInstance.transform.localScale = Vector3.one * explosionRadius / 4;
        Destroy(explosionEffectInstance, 1f);
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
