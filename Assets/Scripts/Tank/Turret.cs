using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class Turret : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] List<Transform> turretBarrels;

    public TurretData turretData;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0;

    private ObjectPool bulletPool;
    [SerializeField] int bulletPoolCount = 10;

    private AudioSource audioSource;

    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
        bulletPool = GetComponent<ObjectPool>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        UpdateTurretData(this.turretData);
    }

    private void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = turretData.reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                //GameObject bullet = Instantiate(bulletPrefab);
                GameObject bullet = bulletPool.CreateObject();
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Initialize(turretData.bulletData, tag);
                foreach (var collider in tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }

            PlayShootSound();
        }
    }

    private void PlayShootSound()
    {
        if (audioSource != null)
            audioSource.Play();
    }

    public void UpdateTurretData(TurretData turretData)
    {
        this.turretData = turretData;

        bulletPool.Initialize(turretData.bulletPrefab, bulletPoolCount);

        if (turretData.sprite != null) {
            spriteRenderer.sprite = turretData.sprite;
            transform.localPosition = new Vector3(turretData.spriteOffset, 0, 0);
        }
    }
}
