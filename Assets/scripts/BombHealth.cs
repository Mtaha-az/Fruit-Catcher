using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object the game object collided with has the tag "ground"
        if (collision.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
}
