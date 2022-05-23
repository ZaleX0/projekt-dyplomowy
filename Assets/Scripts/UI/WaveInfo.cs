using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveInfo : MonoBehaviour
{
    [SerializeField] WaveSpawner waveSpawner;
    [SerializeField] TextMeshProUGUI waveNumberText;
    [SerializeField] TextMeshProUGUI enemiesLeftText;

    private void Update()
    {
        waveNumberText.text = $"Wave: {waveSpawner.currentWaveNumber}";
        enemiesLeftText.text = $"Enemies Left: {waveSpawner.numberOfEnemiesLeft}";
    }
}
