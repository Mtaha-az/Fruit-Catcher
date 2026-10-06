using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsHealth : MonoBehaviour
{
    // Reference to the spawner to notify it when the prefab collides with the bucket
    public InfiniteSpawner spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object the prefab collided with has the tag "bucket"
        if (collision.CompareTag("bucket"))
        {
            // Notify the spawner that this prefab collided with the bucket
            if (spawner != null)
            {
                spawner.OnPrefabCollisionWithBucket(gameObject);
            }

            // Destroy the current game object after it collides with the bucket
            Destroy(gameObject);
        }

        // Check if the object the prefab collided with has the tag "ground"
        if (collision.CompareTag("ground"))
        {
            // Destroy the current game object after it collides with the ground
            Destroy(gameObject);
        }
    }
}
