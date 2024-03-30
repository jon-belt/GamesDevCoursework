using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState{SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        //all useful fields for each wave of enemies
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;
    public LightingManager lightingManager;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points set up");
        }
    }

    void Update()
    {   
        //gets the time of day, as enemies only spawn in the night
        float currentTime = lightingManager.GetTimeOfDay();
        bool isNight = currentTime >= 18 || currentTime < 4;

        //if the player is between waves, or if it is during the daytime, the state will be 'WAITING'
        if (isNight && state == SpawnState.WAITING)
        {
            if(!EnemyIsAlive())
            {
                //next wave can start
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        //if its time to start spawning a wave
        if (isNight && waveCountdown <= 0)
        {
            //if a wave is not already being spawned
            if (state != SpawnState.SPAWNING)
            {
                //start spawning
                StartCoroutine( SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed...");

        state = SpawnState.COUNTING;            //sets state back to counting
        waveCountdown = timeBetweenWaves;       //initiates countdown

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All Waves Completed");

            //increase user money here
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        //instead of checking every frame, check every second.  As I am looping through all game objects, every frame would be incredibly taxing.
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }


    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        //spawn an enemy for number of enemies in wave, using 'SpawnEnemy'
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds( 1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        // spawn the enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);        //debugging purposes

        Transform _sp = spawnPoints[Random.Range (0, spawnPoints.Length)];

        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}