using UnityEngine;

public class OreSpawner : MonoBehaviour
{
    public GameObject orePrefab;
    public float spawnRadius = 10f;
    public int spawnAmount = 5;
    public LightingManager lightingManager;
    
    private bool spawning = true;

    void Start()
    {
        //sets lighting manager for time control
        lightingManager = FindObjectOfType<LightingManager>();
        if (lightingManager == null)
        {
            Debug.LogError("LightingManager not found");
        }
        SpawnOres();    //play once to populate the map initially
    }

    void Update()
    {
        float currentTime = lightingManager.GetTimeOfDay();

        //due to the nature of the lighting manager and the current time variable, the only consistent way to trigger this is between 0 & 0.1
        //a bool is used to control so that it only triggers once, otherwise it would trigger for the amount of frames between 0 & 0.1
        if (currentTime >= 0.01 && currentTime <= 0.02 && spawning)
        {
            Debug.Log("New Ore Spawned");
            SpawnOres();
            spawning = false;
        }
        else if (currentTime > 0.02)
        {
            spawning = true;    //resets bool for next night
        }
    }

    void SpawnOres()
    {
        //loops for each ore being spawned
        for (int i = 0; i < spawnAmount; i++)
        {
            //below code is to spawn one ore
            Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;  //sets position of new ore
            spawnPos.y = transform.position.y;

            //below code ensures that the ores spawn touching the ground, so we don't have floating ore
            RaycastHit hit;
            if (Physics.Raycast(spawnPos + Vector3.up * 50, Vector3.down, out hit, Mathf.Infinity))
            {
                spawnPos.y = hit.point.y; //set y position on the ground
                spawnPos.y += 0.101f;   //for some reason, with these parameters, this is the smallest number i can use

                //check for collider overlaps
                Collider[] hitColliders = Physics.OverlapSphere(spawnPos, 0.1f); //0.5f = sample size

                //if no object overlap, spawn object using instantiate
                if (hitColliders.Length == 0)
                {
                    spawnPos.y -= 0.201f;   //readjusts y so that the prefab sits appropriately on the ground
                                            //the adjustments with the y position are because the prefab im using has an odd shaped collider
                    Instantiate(orePrefab, spawnPos, Quaternion.identity);
                }
            }
        }
    }
}
