using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;

    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(BulletData bulletData)
    {
        this.bulletData = bulletData;
        startPosition = transform.position;
        rigidbody.velocity = -transform.right * bulletData.speed;
    }

    private void Start()
    {
        if (bulletData.sprite != null)
            spriteRenderer.sprite = bulletData.sprite;
    }

    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance >= bulletData.maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rigidbody.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void HitEnemy(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            var damagable = collision.GetComponent<Damagable>();
            if (damagable != null)
            {
                damagable.Hit(bulletData.damage);
            }
            DisableObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitEnemy(collision);
    }
}
