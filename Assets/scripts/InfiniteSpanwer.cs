using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawner : MonoBehaviour
{
    // Array to hold the spawn points
    public Transform[] spawnPoints;

    // Array to hold the prefabs that will be spawned randomly after the first three
    public GameObject[] prefabsToSpawn;

    // Array to hold the first 3 specific prefabs to be spawned
    public GameObject[] firstThreePrefabs;

    // Time interval between each spawn
    public float spawnInterval = 4f;

    // Counter for how many specific objects have been spawned
    private int specificSpawnCounter = 0;

    // Flag to determine if we are still spawning from the first three prefabs
    private bool spawningSpecificPrefabs = true;

    // Gravity scale adjustment interval (public to control in Inspector)
    public float gravityScaleIncreaseInterval = 15f;

    // Starting gravity scale for all objects
    public float initialGravityScale = 0.2f;

    // Gravity scale increase after each interval
    public float gravityScaleIncrement = 0.1f;

    // Current gravity scale (starts with initial gravity scale)
    private float currentGravityScale;

    void Start()
    {
        currentGravityScale = initialGravityScale;
        StartCoroutine(SpawnObjects());
        StartCoroutine(IncreaseGravityOverTime());
    }

    IEnumerator SpawnObjects()
    {
        // Infinite loop for continuous spawning
        while (true)
        {
            if (spawningSpecificPrefabs)
            {
                // Spawn specific prefabs one by one until each one collides with the bucket
                SpawnSpecificPrefab(firstThreePrefabs[specificSpawnCounter]);
            }
            else
            {
                if (spawnInterval == 4f)
                {
                    spawnInterval = 2f;
                   // Debug.Log("spawn interval changed to 2 seconds");
                }
                // After spawning the first three prefabs, spawn random prefabs
                int randomPrefabIndex = Random.Range(0, prefabsToSpawn.Length);
                SpawnPrefab(prefabsToSpawn[randomPrefabIndex]);
            }

            // Wait for the next spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator IncreaseGravityOverTime()
    {
        // Infinite loop for increasing gravity scale over time
        while (true)
        {
            // Wait for the specified interval before increasing gravity scale
            yield return new WaitForSeconds(gravityScaleIncreaseInterval);

            // Increase the current gravity scale
            currentGravityScale += gravityScaleIncrement;

            Debug.Log("Increased gravity scale to: " + currentGravityScale);
        }
    }

    // Spawns one of the first three specific prefabs
    void SpawnSpecificPrefab(GameObject prefab)
    {
        // Randomly choose a spawn point from the array
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Instantiate the prefab at the selected spawn point's position and rotation
        GameObject spawnedObject = Instantiate(prefab, spawnPoints[randomSpawnPointIndex].position, spawnPoints[randomSpawnPointIndex].rotation);

        // Set the initial gravity scale for the spawned object
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = currentGravityScale;  // Apply the current gravity scale to the spawned object
        }
        else
        {
            Debug.LogWarning("Spawned object does not have a Rigidbody2D component!");
        }

        // Assign the spawner reference to the spawned object’s FruitsHealth script
        FruitsHealth fruitHealth = spawnedObject.GetComponent<FruitsHealth>();
        if (fruitHealth != null)
        {
            fruitHealth.spawner = this;  // Set the spawner reference
        }
    }

    // Spawns a random prefab
    void SpawnPrefab(GameObject prefab)
    {
        // Randomly choose a spawn point from the array
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Instantiate the prefab at the selected spawn point's position and rotation
        GameObject spawnedObject = Instantiate(prefab, spawnPoints[randomSpawnPointIndex].position, spawnPoints[randomSpawnPointIndex].rotation);

        // Set the initial gravity scale for the spawned object
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = currentGravityScale;  // Apply the current gravity scale to the spawned object
        }
        else
        {
            Debug.LogWarning("Spawned object does not have a Rigidbody2D component!");
        }
    }

    // Called when a prefab from firstThreePrefabs collides with the bucket
    public void OnPrefabCollisionWithBucket(GameObject collidedPrefab)
    {
        // Increase the counter to move to the next prefab in the array
        specificSpawnCounter++;

        // Check if all 3 specific prefabs have been spawned
        if (specificSpawnCounter >= firstThreePrefabs.Length)
        {
            spawningSpecificPrefabs = false;  // Start spawning random prefabs after the first three
        }
    }
}
