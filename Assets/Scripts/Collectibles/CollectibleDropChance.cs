using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleDropChance : MonoBehaviour
{
    [SerializeField] int weaponDropRate = 10;
    [SerializeField] int healthDropRate = 20;

    [SerializeField] GameObject healthCollectiblePrefab;
    [SerializeField] GameObject[] weaponCollectiblePrefabs;

    public void DropCollectible()
    {
        int r = Random.Range(0, 100);

        if (r < weaponDropRate)
            DropWeapon();

        else if (r < healthDropRate + weaponDropRate)
            DropHealth();
    }

    private void DropHealth()
    {
        if (healthCollectiblePrefab != null) {
            Instantiate(healthCollectiblePrefab, transform.position, Quaternion.identity);
        }
    }

    private void DropWeapon()
    {
        if (weaponCollectiblePrefabs != null && weaponCollectiblePrefabs.Length > 0) {
            int index = Random.Range(0, weaponCollectiblePrefabs.Length);
            var weapon = weaponCollectiblePrefabs[index];
            Instantiate(weapon, transform.position, Quaternion.identity);
        }
    }
}
