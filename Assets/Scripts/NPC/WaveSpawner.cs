using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING };

    public Transform enemyPrefab; // Single enemy prefab to spawn
    public Transform[] spawnPoints;
    public LightingManager lightingManager;

    public float minSpawnRate = 2f;
    public float maxSpawnRate = 5f;
    private float spawnTimer;

    public int maxEnemiesPerNight = 10;
    private int enemiesSpawnedTonight = 0;

    private SpawnState state = SpawnState.WAITING;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points set up");
        }

        // Initialize spawnTimer with a random value within the defined range
        spawnTimer = Random.Range(minSpawnRate, maxSpawnRate);
    }

    void Update()
    {   
        float currentTime = lightingManager.GetTimeOfDay();
        bool isNight = currentTime >= 18 || currentTime < 6;

        // Reset for the next night
        if (!isNight)
        {
            state = SpawnState.WAITING;
            enemiesSpawnedTonight = 0;
        }

        // If it's night and we haven't reached the max enemy count
        else if (isNight && enemiesSpawnedTonight < maxEnemiesPerNight)
        {
            if (state == SpawnState.WAITING)
            {
                state = SpawnState.SPAWNING;
            }

            if (state == SpawnState.SPAWNING)
            {
                if (spawnTimer <= 0)
                {
                    SpawnEnemy(enemyPrefab);
                    // After spawning, reset the timer with another random value
                    spawnTimer = Random.Range(minSpawnRate, maxSpawnRate);
                    enemiesSpawnedTonight++;
                }
                else
                {
                    spawnTimer -= Time.deltaTime;
                }
            }
        }
    }

    void SpawnEnemy(Transform _enemyPrefab)
    {
        Debug.Log("Spawning Enemy: " + _enemyPrefab.name); // Debugging purposes

        if (spawnPoints.Length > 0)
        {
            Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(_enemyPrefab, _sp.position, _sp.rotation);
        }
    }
}
