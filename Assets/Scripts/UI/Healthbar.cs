using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Damagable playerDamagable;
    [SerializeField] Image currentHealthbar;

    private void Update()
    {
        currentHealthbar.fillAmount = playerDamagable.Health / 100f;
    }
}
