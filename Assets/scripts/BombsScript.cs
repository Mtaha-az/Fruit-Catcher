using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsScript : MonoBehaviour
{
    // Array to hold the spawn points
    public Transform[] spawnPoints;

    // Prefab for the bomb to be spawned
    public GameObject bombPrefab;

    // Time interval between each spawn
    public float spawnInterval = 2f;

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
        StartCoroutine(SpawnBombs());
        StartCoroutine(IncreaseGravityOverTime());
    }

    IEnumerator SpawnBombs()
    {
        yield return new WaitForSeconds(15);
        // Infinite loop for continuous bomb spawning
        while (true)
        {
            // Spawn the bomb prefab at a random spawn point
            SpawnBomb();

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

    void SpawnBomb()
    {
        // Randomly choose a spawn point from the array
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Instantiate the bomb prefab at the selected spawn point's position and rotation
        GameObject spawnedBomb = Instantiate(bombPrefab, spawnPoints[randomSpawnPointIndex].position, spawnPoints[randomSpawnPointIndex].rotation);

        // Set the initial gravity scale for the spawned bomb
        Rigidbody2D rb = spawnedBomb.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = currentGravityScale;  // Apply the current gravity scale to the spawned bomb
        }
        else
        {
            Debug.LogWarning("Spawned bomb does not have a Rigidbody2D component!");
        }
    }
}
