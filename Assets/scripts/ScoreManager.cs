using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText1; // TextMeshPro for displaying score1
    public TMP_Text scoreText2; // TextMeshPro for displaying score2
    public TMP_Text highestScoreText; // TextMeshPro for displaying the highest score

    private int score1 = 0;  // Variable for score 1
    private int score2 = 0;  // Variable for score 2
    private int highestScore = 0; // Variable for highest score

    // Start is called before the first frame update
    void Start()
    {
        // Load the highest score from PlayerPrefs, if available
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);

        // Initial display setup
        UpdateScoreText();
    }

    // This function is triggered when an object enters the trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is tagged as "fruits"
        if (other.CompareTag("fruits"))
        {
            IncrementScores(); // Increment score1 and score2

            // Check if the current score1 is higher than the highest score
            if (score1 > highestScore)
            {
                highestScore = score1; // Update highest score
                PlayerPrefs.SetInt("HighestScore", highestScore); // Save the new highest score in PlayerPrefs
                PlayerPrefs.Save(); // Ensure that the data is saved immediately
            }

            UpdateScoreText(); // Update the displayed score values
        }
    }

    // Function to increment the scores
    private void IncrementScores()
    {
        score1++; // Increment score1 by 1
        score2++; // Increment score2 by 1 (since they need to stay the same)
    }

    // Function to update the score display text
    private void UpdateScoreText()
    {
        scoreText1.text = score1.ToString();  // Update score1 text, showing only the number
        scoreText2.text = score2.ToString();  // Update score2 text, showing only the number
        highestScoreText.text = highestScore.ToString(); // Update highest score text, showing only the number
    }
}
