using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    // Array to store the game objects that will be destroyed
    public GameObject[] objectsToDestroy; // Make this public so you can assign objects via the Inspector
    private int objectsDestroyedCount = 0; // To track how many objects are destroyed

    // Reference to the panel, which will be activated when all objects are destroyed
    [SerializeField] private GameObject GameOverPanel; // Serialized field for reference in the Inspector
    Sounds audioManager;
    public LevelCanvesManager levelCanvesManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<Sounds>();
    }
    // This method is triggered when something enters the trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger has the tag "fruits"
        if (other.CompareTag("fruits") && objectsDestroyedCount < objectsToDestroy.Length)
        {
            DestroyNextObject();
        }
    }

    // Method to destroy the next object in the array
    private void DestroyNextObject()
    {
        if (objectsDestroyedCount < objectsToDestroy.Length)
        {
            // Destroy the object at the current index
            Destroy(objectsToDestroy[objectsDestroyedCount]);

            // Increment the counter to track how many objects are destroyed
            objectsDestroyedCount++;

            // If all objects in the array are destroyed, activate the win panel
            if (objectsDestroyedCount == objectsToDestroy.Length)
            {
                ActivateWinPanel();
            }
        }
    }

    // Method to activate the panel
    private void ActivateWinPanel()
    {
        Time.timeScale = 0;
        if (GameOverPanel != null)
        {
            audioManager.PlaySFX(audioManager.gameOver);
            GameOverPanel.SetActive(true);
            if (!levelCanvesManager.isMobile())
            {
                StartCoroutine(ScaleUp1(GameOverPanel.transform));
            }
            else
            {
                StartCoroutine(ScaleUp(GameOverPanel.transform));
            }
        }
    }
    IEnumerator ScaleUp(Transform panelTransform)
    {
        Vector3 initialScale = new Vector3(0, 0, 0);
        Vector3 finalScale = new Vector3(1, 1, 1);
        float duration = 0.3f;
        float elapsedTime = 0;

        panelTransform.localScale = initialScale;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            panelTransform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / duration);
            yield return null;
        }

        panelTransform.localScale = finalScale;
    }
    IEnumerator ScaleUp1(Transform panelTransform)
    {
        Vector3 initialScale = new Vector3(0, 0, 0);
        Vector3 finalScale = new Vector3(0.5f, 0.5f, 1);
        float duration = 0.3f;
        float elapsedTime = 0;

        panelTransform.localScale = initialScale;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            panelTransform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / duration);
            yield return null;
        }

        panelTransform.localScale = finalScale;
    }
}
