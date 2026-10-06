using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketSprites : MonoBehaviour
{ // Public array to store the sprites for changing
    public Sprite[] basketSprites;
    [SerializeField] private GameObject GameOverPanel;
    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    // Track the number of sprite changes
    private int currentSpriteIndex = 0;

    // Flags to ensure sprite changes only happen once per object
    private bool hasCollidedWithPineapple = false;
    private bool hasCollidedWithStrawberry = false;
    private bool hasCollidedWithLemon = false;
    Sounds audioManager;
    public LevelCanvesManager levelCanvesManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<Sounds>();
    }

    void Start()
    {
        // Get the SpriteRenderer component attached to the basket
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Detect collisions with the specific game objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fruits")) 
        {   
        audioManager.PlaySFX(audioManager.fruitsCollecting);
        }
        // Check for collision with pineapple and change the sprite
        if (collision.gameObject.CompareTag("fruits")&& !hasCollidedWithPineapple)
        {
            ChangeSprite();
            hasCollidedWithPineapple = true; // Ensure it only happens once
            //Debug.Log("1st sprite changed");
        }

        // Check for collision with strawberry and change the sprite
        else if (collision.gameObject.CompareTag("fruits") && !hasCollidedWithStrawberry)
        {
            ChangeSprite();
            hasCollidedWithStrawberry = true; // Ensure it only happens once
           // Debug.Log("2st sprite changed");
        }

        // Check for collision with lemon and change the sprite
        else if (collision.gameObject.CompareTag("fruits") && !hasCollidedWithLemon)
        {
            ChangeSprite();
            hasCollidedWithLemon = true; // Ensure it only happens once
            //Debug.Log("3st sprite changed");
        }
        if (collision.gameObject.CompareTag("bomb"))
        {
            Time.timeScale = 0;
            if (GameOverPanel != null)
            {
                audioManager.PlaySFX(audioManager.gameOver);
                GameOverPanel.SetActive(true);
                if (levelCanvesManager.isMobile())
                {
                    StartCoroutine(ScaleUp(GameOverPanel.transform));
                }
                else
                {
                    StartCoroutine(ScaleUp1(GameOverPanel.transform));
                }
            }
            // Destroy the bomb object
            Destroy(collision.gameObject);
        }
    }

    // Method to change the sprite
    private void ChangeSprite()
    {
        // Only change sprite if there's a next one available
        if (currentSpriteIndex < basketSprites.Length)
        {
            spriteRenderer.sprite = basketSprites[currentSpriteIndex];
            currentSpriteIndex++;
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
