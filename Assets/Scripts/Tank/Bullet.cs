using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;

    private string shootersTag;
    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        UpdateBulletSprite();
    }
    private void OnEnable()
    {
        UpdateBulletSprite();
    }
    private void Update()
    {
        UpdateBulletSprite();

        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance >= bulletData.maxDistance) {
            DisableObject();
        }
    }



    public void Initialize(BulletData bulletData, string shootersTag)
    {
        this.bulletData = bulletData;
        this.shootersTag = shootersTag;
        startPosition = transform.position;
        rigidbody.velocity = -transform.right * bulletData.speed;
    }

    private void UpdateBulletSprite()
    {
        spriteRenderer.sprite = bulletData.sprite;
    }

    private void DisableObject()
    {
        rigidbody.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void HitTag(Collider2D collision, string tagToHit)
    {
        if (collision.tag == tagToHit)
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
        if (shootersTag == "Player")
            HitTag(collision, "Enemy");

        else if (shootersTag == "Enemy")
            HitTag(collision, "Player");
    }
}
