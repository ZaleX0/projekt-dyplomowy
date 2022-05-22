using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] float lifetimeInSeconds = 10;

    private void Start()
    {
        if (lifetimeInSeconds > 0)
            Destroy(gameObject, lifetimeInSeconds);
    }
}
