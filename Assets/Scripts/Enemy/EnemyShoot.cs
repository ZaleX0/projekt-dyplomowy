using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyShoot : MonoBehaviour
{
    public UnityEvent OnShoot = new UnityEvent();

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        OnShoot.Invoke();
    }
}
