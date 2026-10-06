using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaskitController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of the basket
    public float boundary = 8f;   // Screen boundary for the basket
    private float maxSpeed = 12f; // Maximum speed the basket can reach
    private float speedIncrease = 0.5f; // Amount by which speed increases

    private void Start()
    {
        // Start the coroutine to increase speed over time
        StartCoroutine(IncreaseSpeedOverTime());
    }

    private void Update()
    {
        // Get horizontal input
        float moveInput = Input.GetAxis("Horizontal"); // For keyboard
        float touchInput = 0f;

        // Check for touch input on mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                // Invert the deltaPosition.x to correct the movement direction
                touchInput = touch.deltaPosition.x * Time.deltaTime; // Move basket based on touch delta
            }
        }

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(moveInput + touchInput, 0, 0);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Clamp basket position within screen boundaries
        float clampedX = Mathf.Clamp(transform.position.x, -boundary, boundary);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

    }

    // Coroutine to increase speed over time
    private IEnumerator IncreaseSpeedOverTime()
    {
        while (moveSpeed < maxSpeed)
        {
            yield return new WaitForSeconds(45f); // Wait for 45 seconds
            moveSpeed = Mathf.Min(moveSpeed + speedIncrease, maxSpeed); // Increase speed and clamp it to maxSpeed
        }
    }
}
