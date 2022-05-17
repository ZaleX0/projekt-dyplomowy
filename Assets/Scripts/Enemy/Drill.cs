using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        DamagePlayer(collision);
    }

    private void DamagePlayer(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var damagable = collision.GetComponent<Damagable>();
            if (damagable != null)
            {
                damagable.Hit(damage);
            }
        }
    }
}
