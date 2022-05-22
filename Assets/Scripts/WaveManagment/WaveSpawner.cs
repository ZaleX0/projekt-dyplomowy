using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnedEnemiesParent;
    public Transform playerObject;

    public GameObject drillerPrefab;
    public GameObject gunnerPrefab;
    public GameObject boomerPrefab;
    public Transform[] spawnPoints;
    public int currentWaveNumber;

    public List<GameObject> enemies;

    private int numberOfEnemiesLeft;
    [SerializeField] float delayBeetweenEnemies = 0.5f;

    private void Start()
    {
        CreateEnemiesParentObjectIfNeeded();
        currentWaveNumber++;
        SpawnWave();
    }

    private void Update()
    {
        UpdateNumberOfEnemiesLeft();
        Debug.Log($"numberOfEnemiesLeft: {numberOfEnemiesLeft}");

        if (numberOfEnemiesLeft <= 0) {
            currentWaveNumber++;
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        InstantiateWave();
        StartCoroutine(ActivateWaveEnemies());
    }

    private void InstantiateWave()
    {
        enemies = new List<GameObject>();

        numberOfEnemiesLeft = GetNumberOfEnemies(currentWaveNumber);

        for (int i = 1; i <= numberOfEnemiesLeft; i++) {

            if (i % 3 == 0)
                enemies.Add(InstantiateInactiveEnemy(boomerPrefab));

            else if (i % 4 == 0)
                enemies.Add(InstantiateInactiveEnemy(gunnerPrefab));

            else
                enemies.Add(InstantiateInactiveEnemy(drillerPrefab));
        }
    }

    private IEnumerator ActivateWaveEnemies()
    {
        List<GameObject> enemiesCopy = new List<GameObject>(enemies);

        for (int i = 0; i < enemiesCopy.Count; i++) {

            enemiesCopy[i].SetActive(true);

            yield return new WaitForSeconds(delayBeetweenEnemies);
        }
    }

    private GameObject InstantiateInactiveEnemy(GameObject enemyPrefab)
    {
        Transform spawnPoint = GetRandomSpawnPoint();
        var spawnedEnemy = Instantiate(
            enemyPrefab,
            spawnPoint.position,
            spawnPoint.rotation,
            spawnedEnemiesParent);

        spawnedEnemy.SetActive(false);

        // Set target object to follow
        spawnedEnemy.GetComponent<EnemyMovement>().targetObject = playerObject;

        return spawnedEnemy;
    }

    private void UpdateNumberOfEnemiesLeft()
    {
        numberOfEnemiesLeft = spawnedEnemiesParent.childCount;
    }

    private void CreateEnemiesParentObjectIfNeeded()
    {
        if (spawnedEnemiesParent == null) {
            spawnedEnemiesParent = new GameObject("Enemies").transform;
            spawnedEnemiesParent.SetParent(this.transform);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        int index = UnityEngine.Random.Range(0, spawnPoints.Length);
        return spawnPoints[index];
    }

    private int GetNumberOfEnemies(int waveNumber)
    {
        float function(float n)
        {
            return n * Mathf.Log(n) + 3;
        }
        return (int)Mathf.Ceil(function(waveNumber));
    }
}
