using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] GameObject explosionEffect;

    public void Explode()
    {
        GameObject explosionEffectInstance = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(explosionEffectInstance, 0.5f);
    }
}
